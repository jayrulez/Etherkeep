using AspNet.Security.OAuth.Validation;
using Etherkeep.Data;
using Etherkeep.Data.Entities;
using Etherkeep.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenIddict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Controllers
{
    [Route("api/[controller]")]
    public class ExchangeRatesController : BaseController
    {
        private IExchangeRateService ExchangeRateService;
        public ExchangeRatesController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, IExchangeRateService exchangeRateService, ILoggerFactory loggerFactory)
            : base(applicationDbContext, userManager, loggerFactory)
        {
            this.ExchangeRateService = exchangeRateService;
            _logger = loggerFactory.CreateLogger<ExchangeRatesController>();
        }


        public async Task<IActionResult> GetExhangeRate(string currencyCode)
        {
            var exchangeRate = await ExchangeRateService.GetExchangeRateAsync(currencyCode);

            return Ok(exchangeRate);
        }
    }
}
