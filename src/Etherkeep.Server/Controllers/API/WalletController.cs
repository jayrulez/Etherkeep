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
using Microsoft.EntityFrameworkCore;
using Etherkeep.Server.ViewModels.Shared;
using Etherkeep.Server.ViewModels.Account;

namespace Etherkeep.Server.Controllers.API
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class WalletController : BaseController
    {
        public WalletController(
            ApplicationDbContext applicationDbContext,
            OpenIddictUserManager<User> userManager,
            ILoggerFactory loggerFactory) : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpGet, Route("balance")]
        public async Task<IActionResult> BalanceAction()
        {
            try
            {
                var user = await GetCurrentUserAsync();

                var wallet = _applicationDbContext.Wallets.Where(e => e.UserId.Equals(user.Id)).FirstOrDefault();

                if (wallet == null)
                {
                    return BadRequest();
                }

                return Ok(wallet.Balance);
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
