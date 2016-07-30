using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNet.Security.OAuth.Validation;
using System;
using OpenIddict;
using Etherkeep.Data.Entities;
using Etherkeep.Data;

namespace Etherkeep.Server.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    //[Route("api/[controller]")]
    [Route("api/wallets")]
    public class WalletsController : BaseController
    {
        public WalletsController(
            ApplicationDbContext applicationDbContext,
            OpenIddictUserManager<User> userManager,
            ILoggerFactory loggerFactory) : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AccountsController>();
        }

        [HttpGet, Route("{id}/balance")]
        public async Task<IActionResult> BalanceAction(string id)
        {
            try
            {
                var user = await GetCurrentUserAsync();

                var wallet = _applicationDbContext.UserWallets.Where(e => e.UserId.Equals(user.Id) && e.Id.Equals(id)).FirstOrDefault();

                if (wallet == null)
                {
                    return BadRequest();
                }

                return Ok(new { balance = wallet.Balance });
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
