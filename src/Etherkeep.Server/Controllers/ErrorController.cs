using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenIddict;
using Etherkeep.Data;
using Etherkeep.Data.Entities;
using Etherkeep.Server.ViewModels.Shared;

namespace Etherkeep.Server.Controllers
{
    public class ErrorController : BaseController
    {
        public ErrorController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory)
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ErrorController>();
        }

        [HttpGet, HttpPost, Route("~/error")]
        public object Error()
        {
            // If the error was not caused by an invalid
            // OIDC request, display a generic error page.
            var response = HttpContext.GetOpenIdConnectResponse();

            if (response == null)
            {
                return null;
            }

            return new ErrorViewModel()
            {
                Error = response.Error,
                ErrorDescription = response.ErrorDescription
            };
        }
    }
}
