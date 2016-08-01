using Etherkeep.Data;
using Etherkeep.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenIddict;
using Etherkeep.Server.Models.Extensions;
using System.Linq;
using System;
using Etherkeep.Server.ViewModels.Shared;
using Etherkeep.Server.Shared.Constants;

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
        public IActionResult GetCurrenciesAsync()
        {
            try
            {
                var currencies = _applicationDbContext.Currencies.ToList().ToModel();

                return Ok(currencies);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return BadRequest(new ErrorViewModel { Error = ErrorCode.ServerError, ErrorDescription = ex.Message });
            }
        }

        [HttpGet, Route("{code}")]
        public IActionResult GetCurrencyAsync(string code)
        {
            try
            {
                var currency = _applicationDbContext.Currencies.FirstOrDefault(e => e.Code.Equals(code));

                if(currency == null)
                {
                    return BadRequest(new ErrorViewModel
                    {
                        Error = ErrorCode.NotFound,
                        ErrorDescription = $"A currency with Code='{code}' could not be found."
                    });
                }

                return Ok(currency.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return BadRequest(new ErrorViewModel { Error = ErrorCode.ServerError, ErrorDescription = ex.Message });
            }
        }
    }
}
