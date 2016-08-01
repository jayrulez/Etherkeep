using Etherkeep.Server.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Services
{
    public interface IExchangeRateService
    {
        Task<ExchangeRateModel> GetExchangeRateAsync(string CurrencyCode);
        Task<IList<ExchangeRateModel>> GetExchangeRatesAsync();
    }
}
