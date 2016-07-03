using AspNet.Security.OAuth.Validation;
using Etherkeep.Server.Data;
using Etherkeep.Server.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenIddict;

namespace Etherkeep.Server.Controllers.API
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class SessionController : BaseController
    {
        public SessionController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory) :base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SessionController>();
        }
    }
}
