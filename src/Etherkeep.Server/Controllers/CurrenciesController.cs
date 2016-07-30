using AspNet.Security.OAuth.Validation;
using Etherkeep.Data;
using Etherkeep.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenIddict;
using System.Threading.Tasks;

namespace Etherkeep.Server.Controllers
{
    [Route("api/[controller]")]
    public class CurrenciesController : BaseController
    {
        public CurrenciesController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory) 
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CurrenciesController>();
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetCurrenciesAsync()
        {
            var currencies = await _applicationDbContext.Currencies.ToListAsync();

            return Ok(currencies);
        }
    }
}
