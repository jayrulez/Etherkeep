using Etherkeep.Server.Data;
using Etherkeep.Server.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenIddict;
using System;
using System.Threading.Tasks;

namespace Etherkeep.Server.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly OpenIddictUserManager<User> _userManager;
        protected ILogger _logger;

        public BaseController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<BaseController>();
        }

        protected async Task<User> GetCurrentUserAsync()
        {
            var id = _userManager.GetUserId(User);

            if(id == null)
            {
                return await Task.FromResult<User>(null);
            }

            return await _applicationDbContext.Users
                .FirstOrDefaultAsync(e => e.Id.Equals(Guid.Parse(id)));
        }
    }
}
