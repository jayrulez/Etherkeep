using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using OpenIddict;
using System.Threading.Tasks;
using System;
using Etherkeep.Shared.Services.Email;
using Etherkeep.Data;
using Etherkeep.Data.Entities;

namespace Etherkeep.Accounts.Controllers
{
    public class HomeController : BaseController
    {
        private IEmailSender EmailSender;
        public HomeController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, IEmailSender emailSender, ILoggerFactory loggerFactory) 
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HomeController>();

            this.EmailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet, Route("test")]
        public async Task<IActionResult> TestAction()
        {
            await EmailSender.SendEmailAsync("", "test email", "This is a test message");

            return Ok();
        }
    }
}
