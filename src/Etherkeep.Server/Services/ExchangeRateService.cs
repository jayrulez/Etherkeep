using Etherkeep.Server.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        public Task<ExchangeRateModel> GetExchangeRateAsync(string CurrencyCode)
        {
            var exchangeRate = new ExchangeRateModel() {
                Value = 1
            };

            return Task.FromResult<ExchangeRateModel>(exchangeRate);
        }
        public Task<IList<ExchangeRateModel>> GetExchangeRatesAsync()
        {
            var exchangeRates = new List<ExchangeRateModel>();

            return Task.FromResult<IList<ExchangeRateModel>>(exchangeRates);
        }
    }
}
