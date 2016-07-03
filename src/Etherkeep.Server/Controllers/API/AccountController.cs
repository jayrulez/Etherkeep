using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNet.Security.OAuth.Validation;
using System;
using Etherkeep.Server.ViewModels;
using Etherkeep.Server.ViewModels.Extensions;
using Etherkeep.Server.Services;
using Etherkeep.Server.Data;
using Etherkeep.Server.Data.Entities;
using Etherkeep.Server.Data.Repository;
using OpenIddict;
using Etherkeep.Server.ViewModels.Authorization;

namespace Etherkeep.Server.Controllers.API
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public AccountController(
            ApplicationDbContext applicationDbContext,
            OpenIddictUserManager<User> userManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory) : base(applicationDbContext, userManager, loggerFactory)
        {
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [Route("activities")]
        public async Task<IActionResult> ActivitiesAction(int? page)
        {
            try
            {
                int pageNumber = page ?? 1;

                int pageSize = 10;

                var user = await GetCurrentUserAsync();

                var activities = _applicationDbContext.Activities.Where(e => e.UserId == user.Id);

                var result = new PagedResult<ActivityViewModel>
                {
                    TotalCount = activities.Count(),
                    Items = activities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToViewModel()
                };

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest(ModelState);
        }

        [Route("balance")]
        public async Task<IActionResult> BalanceAction()
        {
            try
            {
                var user = await GetCurrentUserAsync();

                var wallet = _applicationDbContext.Wallets.Where(e => e.UserId.Equals(user.Id)).FirstOrDefault();

                return Ok(wallet.Balance);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest(ModelState);
        }

        [Route("change_email")]
        public IActionResult ChangeEmailAction()
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

            return BadRequest(ModelState);
        }

        [Route("confirm_email")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmailAction(Guid userId, string code)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());

                if (user == null)
                {
                    return BadRequest(new ErrorViewModel {
                        Error = "",
                        ErrorDescription = ""
                    });
                }

                var result = await _userManager.ConfirmEmailAsync(user, code);

                if(result.Succeeded)
                {
                    return Ok();
                }else
                {
                    ModelState.AddModelError("", "");
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest(ModelState);
        }

        [Route("change_phone_number")]
        public IActionResult ChangePhoneNumberAction()
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

            return BadRequest(ModelState);
        }

        [Route("confirm_phone_number")]
        public IActionResult ConfirmPhoneNumberAction()
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

            return BadRequest(ModelState);
        }
    }
}
