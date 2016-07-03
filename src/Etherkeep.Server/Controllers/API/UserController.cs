using AspNet.Security.OAuth.Validation;
using Etherkeep.Server.Models;
using Etherkeep.Server.ViewModels.Extensions;
using Etherkeep.Server.Data;
using Etherkeep.Server.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using OpenIddict;

namespace Etherkeep.Server.Controllers.API
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public UserController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory) 
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<UserController>();
        }

        [HttpGet("me")]
        public async Task<IActionResult> MeAction()
        {
            try
            {
                var user = await GetCurrentUserAsync();

                return Ok(user.ToViewModel());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return BadRequest(new ErrorModel
                {
                    Error = "internal_error",
                    ErrorDescription = ex.Message
                });
            }
        }
    }
}
