using Microsoft.AspNetCore.Mvc;
using Etherkeep.Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Etherkeep.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using OpenIddict;
using System.Threading.Tasks;
using System;

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
        public IActionResult TestAction()
        {
            return Ok();
        }
    }
}
