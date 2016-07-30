using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Shared.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        public Task<double> GetExchangeRateAsync(string CurrencyCode)
        {
            return Task.FromResult<double>(1);
        }
    }
}
