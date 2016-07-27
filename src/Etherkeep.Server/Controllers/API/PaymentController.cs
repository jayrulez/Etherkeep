using AspNet.Security.OAuth.Validation;
using Etherkeep.Server.Models;
using Etherkeep.Server.Data;
using Etherkeep.Server.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenIddict;
using Etherkeep.Server.ViewModels.Payment;
using Etherkeep.Server.ViewModels.Extensions;
using Etherkeep.Server.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Etherkeep.Server.Services;

namespace Etherkeep.Server.Controllers.API
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class PaymentController : BaseController
    {
        private IExchangeRateService _exchangeRateService;
        private User FindReceiver(ReceiverType receiverType, string receiver)
        {
            if (receiverType == ReceiverType.EmailAddress)
            {
                var emailAddress = _applicationDbContext.EmailAddresses
                    .Include(e => e.User)
                    .FirstOrDefault(e => e.Address == receiver);

                if (emailAddress != null)
                {
                    return emailAddress.User;
                }
            }
            else if (receiverType == ReceiverType.MobileNumber)
            {
                var mobileNumber = _applicationDbContext.MobileNumbers
                    .Include(e => e.User)
                    .FirstOrDefault(e => e.FullMobileNumber == receiver);

                if (mobileNumber != null)
                {
                    return mobileNumber.User;
                }
            }
            return null;
        }

        public PaymentController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, IExchangeRateService exchangeRateService, ILoggerFactory loggerFactory)
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PaymentController>();
            _exchangeRateService = exchangeRateService;
        }

        [HttpPost, Route("request")]
        public async Task<IActionResult> RequestAction([FromBody] RequestPaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();

                using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var paymentRequest = new PaymentRequest()
                        {
                            SenderId = user.Id,
                            ReceiverId = model.ReceiverId,
                            CurrencyCode = model.CurrencyCode,
                            Amount = model.Amount,
                            Status = PaymentRequestStatus.Pending,
                            CreatedAt = DateTime.UtcNow
                        };

                        _applicationDbContext.PaymentRequests.Add(paymentRequest);

                        await _applicationDbContext.SaveChangesAsync();

                        dbTransaction.Commit();

                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();

                        _logger.LogCritical(ex.Message);

                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }

            return BadRequest(ModelState.GetErrorResponse());
        }

        [HttpPost, Route("request_external")]
        public async Task<IActionResult> RequestExternalAction([FromBody] RequestExternalPaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();

                using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var externalPaymentRequest = new ExternalPaymentRequest()
                        {
                            SenderId = user.Id,
                            ReceiverType = model.ReceiverType,
                            Receiver = model.Receiver,
                            CurrencyCode = model.CurrencyCode,
                            Amount = model.Amount,
                            Status = ExternalPaymentRequestStatus.Pending,
                            CreatedAt = DateTime.UtcNow
                        };

                        _applicationDbContext.ExternalPaymentRequests.Add(externalPaymentRequest);

                        await _applicationDbContext.SaveChangesAsync();

                        dbTransaction.Commit();

                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();

                        _logger.LogCritical(ex.Message);

                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }

            return BadRequest(ModelState.GetErrorResponse());
        }

        [HttpPost, Route("send")]
        public async Task<IActionResult> SendAction([FromBody] SendPaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();

                var primaryWallet = await _applicationDbContext.UserPrimaryWallets
                        .Include(e => e.Wallet)
                        .FirstOrDefaultAsync(e => e.UserId == user.Id);

                if (primaryWallet == null)
                {
                    _logger.LogInformation(@"User '{user.Id}' does not have an associated primary wallet.");

                    return BadRequest();
                }

                var currency = await _applicationDbContext.Currencies.FirstOrDefaultAsync(e => e.Code == model.CurrencyCode);

                if(currency == null)
                {
                    return BadRequest();
                }

                var exchangeRate = _exchangeRateService.GetExchangeRate(currency.Code);

                var tokens = model.Amount * exchangeRate;

                var wallet = primaryWallet.Wallet;

                if (wallet.Balance < tokens)
                {
                    return BadRequest();
                }

                using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var payment = new Payment()
                        {
                            SenderId = user.Id,
                            ReceiverId = model.ReceiverId,
                            CurrencyCode = model.CurrencyCode,
                            Amount = model.Amount,
                            ExchangeRate = exchangeRate,
                            Fee = 0,
                            Tokens = tokens,
                            Status = PaymentStatus.Pending,
                            CreatedAt = DateTime.UtcNow
                        };

                        payment.SuspenseWallet = new PaymentSuspenseWallet()
                        {
                            Label = Guid.NewGuid().ToString(),
                            Balance = tokens
                        };

                        _applicationDbContext.Payments.Add(payment);

                        await _applicationDbContext.SaveChangesAsync();

                        dbTransaction.Commit();

                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();

                        _logger.LogCritical(ex.Message);

                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }

            return BadRequest(ModelState.GetErrorResponse());
        }

        [HttpPost, Route("send_external")]
        public async Task<IActionResult> SendExternalAction([FromBody] SendExternalPaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var receiver = FindReceiver(model.ReceiverType, model.Receiver);
                if(receiver != null)
                {
                    return await this.SendAction(new SendPaymentViewModel() {
                        Amount = model.Amount,
                        CurrencyCode = model.CurrencyCode,
                        ReceiverId = receiver.Id
                    });
                }
                var user = await GetCurrentUserAsync();

                var primaryWallet = await _applicationDbContext.UserPrimaryWallets
                        .Include(e => e.Wallet)
                        .FirstOrDefaultAsync(e => e.UserId == user.Id);

                if (primaryWallet == null)
                {
                    _logger.LogInformation(@"User '{user.Id}' does not have an associated primary wallet.");

                    return BadRequest();
                }

                var currency = await _applicationDbContext.Currencies.FirstOrDefaultAsync(e => e.Code == model.CurrencyCode);

                if (currency == null)
                {
                    return BadRequest();
                }

                var exchangeRate = _exchangeRateService.GetExchangeRate(currency.Code);

                var tokens = model.Amount * exchangeRate;

                var wallet = primaryWallet.Wallet;

                if (wallet.Balance < tokens)
                {
                    return BadRequest();
                }

                using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var externalPayment = new ExternalPayment()
                        {
                            SenderId = user.Id,
                            ReceiverType = model.ReceiverType,
                            Receiver = model.Receiver,
                            CurrencyCode = model.CurrencyCode,
                            Amount = model.Amount,
                            ExchangeRate = exchangeRate,
                            Fee = 0,
                            Tokens = tokens,
                            Status = ExternalPaymentStatus.Pending,
                            CreatedAt = DateTime.UtcNow
                        };

                        externalPayment.SuspenseWallet = new ExternalPaymentSuspenseWallet()
                        {
                            Label = Guid.NewGuid().ToString(),
                            Balance = tokens
                        };

                        _applicationDbContext.ExternalPayments.Add(externalPayment);

                        await _applicationDbContext.SaveChangesAsync();

                        dbTransaction.Commit();

                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();

                        _logger.LogCritical(ex.Message);

                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }

            return BadRequest(ModelState.GetErrorResponse());
        }

        [HttpPost, Route("{id:int}/accept_payment")]
        public async Task<IActionResult> AcceptPaymentAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await GetCurrentUserAsync();

                    var payment = _applicationDbContext.Payments
                        .Include(e => e.SuspenseWallet)
                        .FirstOrDefault(e => e.Id == id && e.ReceiverId == user.Id);

                    if (payment == null)
                    {
                        return BadRequest();
                    }

                    if (payment.Status != PaymentStatus.Pending)
                    {
                        return BadRequest();
                    }

                    if (payment.SuspenseWallet == null)
                    {
                        _logger.LogInformation(@"Payment '{payment.Id}' does not have an associated suspense wallet.");

                        return BadRequest();
                    }

                    var primaryWallet = await _applicationDbContext.UserPrimaryWallets
                        .Include(e => e.Wallet)
                        .FirstOrDefaultAsync(e => e.UserId == user.Id);

                    if (primaryWallet == null)
                    {
                        _logger.LogInformation(@"User '{user.Id}' does not have an associated primary wallet.");

                        return BadRequest();
                    }

                    using (var dbTransaction = _applicationDbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            var wallet = primaryWallet.Wallet;

                            wallet.Balance += payment.Amount;
                            payment.SuspenseWallet.Balance -= payment.Amount;
                            payment.Status = PaymentStatus.Accepted;
                            payment.UpdatedAt = DateTime.UtcNow;

                            _applicationDbContext.Entry<Wallet>(wallet).State = EntityState.Modified;
                            _applicationDbContext.Entry<Payment>(payment).State = EntityState.Modified;

                            await _applicationDbContext.SaveChangesAsync();

                            dbTransaction.Commit();

                            return Ok();
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);

                            dbTransaction.Rollback();

                            throw new Exception(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost, Route("{id:int}/accept_payment_request")]
        public async Task<IActionResult> AcceptPaymentRequestAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await GetCurrentUserAsync();

                    var paymentRequest = _applicationDbContext.PaymentRequests
                        .FirstOrDefault(e => e.Id == id && e.ReceiverId == user.Id);

                    if (paymentRequest == null)
                    {
                        return BadRequest();
                    }

                    if (paymentRequest.Status != PaymentRequestStatus.Pending)
                    {
                        return BadRequest();
                    }

                    var primaryWallet = await _applicationDbContext.UserPrimaryWallets
                        .Include(e => e.Wallet)
                        .FirstOrDefaultAsync(e => e.UserId == user.Id);

                    if (primaryWallet == null)
                    {
                        _logger.LogInformation(@"User '{user.Id}' does not have an associated primary wallet.");

                        return BadRequest();
                    }

                    var wallet = primaryWallet.Wallet;

                    if(wallet.Balance < paymentRequest.Amount)
                    {
                        return BadRequest();
                    }

                    var payment = new Payment()
                    {
                        PaymentRequestId = paymentRequest.Id,
                        ReceiverId = paymentRequest.SenderId,
                        SenderId = paymentRequest.ReceiverId,
                        CurrencyCode = paymentRequest.CurrencyCode,
                        Amount = paymentRequest.Amount,
                        ExchangeRate = 1,
                        Fee = 0,
                        Total = paymentRequest.Amount,
                        Tokens = 0,
                        Status = PaymentStatus.Accepted,
                        CreatedAt = DateTime.UtcNow
                    };


                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost, Route("{id:int}/cancel")]
        public IActionResult CancelAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost, Route("{id:int}/cancel_external")]
        public IActionResult CancelInvitationAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost, Route("{id:int}/reject")]
        public IActionResult RejectAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet, Route("{id:int}")]
        public IActionResult PaymentDetailsAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet, Route("external/{id:int}")]
        public IActionResult ExternalPaymentDetailsAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet, Route("request/{id:int}")]
        public IActionResult PaymentRequestDetailsAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet, Route("external_request/{id:int}")]
        public IActionResult ExternalPaymentRequestDetailsAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }
    }
}
