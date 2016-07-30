using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNet.Security.OAuth.Validation;
using System;
using Etherkeep.Server.Models.Extensions;
using OpenIddict;
using Microsoft.EntityFrameworkCore;
using Etherkeep.Server.Models.Account;
using Etherkeep.Data.Entities;
using Etherkeep.Shared.Services.Email;
using Etherkeep.Shared.Services.Sms;
using Etherkeep.Data;
using Etherkeep.Data.Repository;

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
        public async Task<IActionResult> GetActivities(int? page)
        {
            try
            {
                int pageNumber = page ?? 1;

                int pageSize = 10;

                var user = await GetCurrentUserAsync();

                var activities = _applicationDbContext.Activities
                    .Include(e => e.Parameters)
                    .Where(e => e.UserId == user.Id);

                var result = new PagedResult<ActivityModel>
                {
                    TotalCount = activities.Count(),
                    Items = activities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToModel()
                };

                return Ok(result);
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
