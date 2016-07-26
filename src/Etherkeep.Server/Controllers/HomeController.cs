using Microsoft.AspNetCore.Mvc;
using Etherkeep.Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Etherkeep.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using OpenIddict;
using System.Threading.Tasks;

namespace Etherkeep.Server.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory) 
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HomeController>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [Route("test")]
        public async Task<IActionResult> TestAction()
        {
            var users = await _applicationDbContext.Users.ToListAsync();
            var requests = await _applicationDbContext.PaymentRequests.ToListAsync();
            var payments = await _applicationDbContext.PaymentRequests.ToListAsync();
            var externalRequests = await _applicationDbContext.ExternalPaymentRequests.ToListAsync();
            var externalPayments = await _applicationDbContext.ExternalPayments.ToListAsync();

            var emails = await _applicationDbContext.EmailAddresses.ToListAsync();
            var numbers = await _applicationDbContext.MobileNumbers.ToListAsync();

            var countries = await _applicationDbContext.Countries.ToListAsync();
            var currencies = await _applicationDbContext.Currencies.ToListAsync();
            var devices = await _applicationDbContext.Devices.ToListAsync();

            return Ok();
        }
    }
}
