using AspNet.Security.OAuth.Validation;
using Etherkeep.Data;
using Etherkeep.Data.Entities;
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
        public ExchangeRatesController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory)
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ExchangeRatesController>();
        }
    }
}
