using Microsoft.AspNetCore.Mvc;
using Etherkeep.Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Etherkeep.Server.Data.Entities;
using OpenIddict;

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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
