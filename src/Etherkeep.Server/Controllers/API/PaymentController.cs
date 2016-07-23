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

namespace Etherkeep.Server.Controllers.API
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    //[Route("api/[controller]")]
    [Route("api/payments")]
    public class PaymentController : BaseController
    {
        public PaymentController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory)
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PaymentController>();
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
                            Amount = model.Amount
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
        public async Task<IActionResult> RequestExternalAction()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var request = new ExternalPaymentRequest();

                    _applicationDbContext.ExternalPaymentRequests.Add(request);

                    await _applicationDbContext.SaveChangesAsync();

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

        [HttpPost, Route("send")]
        public IActionResult SendAction([FromBody] SendPaymentViewModel model)
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

            return BadRequest(ModelState.GetErrorResponse());
        }

        [HttpPost, Route("send_external")]
        public IActionResult SendExternalAction()
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

        [HttpPost, Route("{id:int}/accept")]
        public IActionResult AcceptAction(int id)
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

        [HttpPost, Route("{id:int}/pay")]
        public IActionResult PayAction()
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
