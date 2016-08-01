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
using Microsoft.EntityFrameworkCore;
using Etherkeep.Server.ViewModels.Shared;
using Etherkeep.Server.Shared.Constants;
using Etherkeep.Server.Models.Extensions;

namespace Etherkeep.Server.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class WalletsController : BaseController
    {
        public WalletsController(
            ApplicationDbContext applicationDbContext,
            OpenIddictUserManager<User> userManager,
            ILoggerFactory loggerFactory) : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ActivitiesController>();
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetWallet(string id)
        {
            try
            {
                var user = await GetCurrentUserAsync();

                var wallet = _applicationDbContext.UserWallets
                    .Where(e => e.UserId.Equals(user.Id) && e.Id.Equals(id)).FirstOrDefault();

                if (wallet == null)
                {
                    return BadRequest(new ErrorViewModel
                    {
                        Error = ErrorCode.NotFound,
                        ErrorDescription = $"A wallet with Id='{id}' could not be found."
                    });
                }

                return Ok(wallet.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return BadRequest(new ErrorViewModel { Error = ErrorCode.ServerError, ErrorDescription = ex.Message });
            }

        }

        [HttpGet, Route("{id}/addresses")]
        public async Task<IActionResult> GetWalletAddresses(string id)
        {
            try
            {
                var user = await GetCurrentUserAsync();

                var wallet = _applicationDbContext.UserWallets
                    .Include(e => e.WalletAddresses)
                    .Where(e => e.UserId.Equals(user.Id) && e.Id.Equals(id)).FirstOrDefault();

                if (wallet == null)
                {
                    return BadRequest(new ErrorViewModel
                    {
                        Error = ErrorCode.NotFound,
                        ErrorDescription = $"A wallet with Id='{id}' could not be found."
                    });
                }

                return Ok(wallet.WalletAddresses.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return BadRequest(new ErrorViewModel { Error = ErrorCode.ServerError, ErrorDescription = ex.Message });
            }
        }
    }
}
