using AspNet.Security.OAuth.Validation;
using Etherkeep.Data;
using Etherkeep.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenIddict;

namespace Etherkeep.Server.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class SessionsController : BaseController
    {
        public SessionsController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory) :base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SessionsController>();
        }
    }
}
