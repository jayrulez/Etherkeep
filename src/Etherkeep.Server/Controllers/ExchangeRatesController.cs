using AspNet.Security.OAuth.Validation;
using Etherkeep.Data;
using Etherkeep.Data.Entities;
using Etherkeep.Server.Services;
using Etherkeep.Server.Shared.Constants;
using Etherkeep.Server.ViewModels.Shared;
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
        private IExchangeRateService _exchangeRateService;
        public ExchangeRatesController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, IExchangeRateService exchangeRateService, ILoggerFactory loggerFactory)
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _exchangeRateService = exchangeRateService;
            _logger = loggerFactory.CreateLogger<ExchangeRatesController>();
        }


        public async Task<IActionResult> GetExhangeRate([FromBody] string currencyCode)
        {
            try
            {
                var exchangeRate = await _exchangeRateService.GetExchangeRateAsync(currencyCode);

                return Ok(exchangeRate);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return BadRequest(new ErrorViewModel { Error = ErrorCode.ServerError, ErrorDescription = ex.Message });
            }
        }

        public async Task<IActionResult> GetExhangeRates()
        {
            try
            {
                var exchangeRates = await _exchangeRateService.GetExchangeRatesAsync();

                return Ok(exchangeRates);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return BadRequest(new ErrorViewModel { Error = ErrorCode.ServerError, ErrorDescription = ex.Message });
            }
        }
    }
}
