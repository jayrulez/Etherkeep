using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNet.Security.OAuth.Validation;
using System;
using Etherkeep.Server.Models.Extensions;
using OpenIddict;
using Microsoft.EntityFrameworkCore;
using Etherkeep.Data.Entities;
using Etherkeep.Data;
using Etherkeep.Server.ViewModels.Shared;
using Etherkeep.Server.Shared.Constants;

namespace Etherkeep.Server.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class ActivitiesController : BaseController
    {
        public ActivitiesController(
            ApplicationDbContext applicationDbContext,
            OpenIddictUserManager<User> userManager,
            ILoggerFactory loggerFactory) : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ActivitiesController>();
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetActivities(int? page, int? size)
        {
            try
            {
                int pageNumber = page ?? 1;
                int pageSize = size ?? 10;
                var user = await GetCurrentUserAsync();

                var activities = _applicationDbContext.Activities
                    .Include(e => e.Parameters)
                    .Where(e => e.UserId == user.Id)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize);

                return Ok(activities.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return BadRequest(new ErrorViewModel { Error = ErrorCode.ServerError, ErrorDescription = ex.Message });
            }
        }
    }
}
