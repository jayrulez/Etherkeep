using System.Security.Claims;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Etherkeep.Server.Data;
using Microsoft.AspNetCore.Identity;
using Etherkeep.Server.Data.Entities;
using Microsoft.Extensions.Logging;
using OpenIddict;

namespace Etherkeep.Server.Controllers.API {
    [Route("api")]
    public class ResourceController : BaseController
    {
        public ResourceController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory) 
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ResourceController>();
        }

        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [HttpGet("message")]
        public IActionResult GetMessage() {
            var identity = User.Identity as ClaimsIdentity;
            if (identity == null) {
                return BadRequest();
            }

            return Content($"{identity.Name} has been successfully authenticated.");
        }
    }
}