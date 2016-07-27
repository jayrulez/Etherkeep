using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        public double GetExchangeRate(string CurrencyCode)
        {
            return 1;
        }
    }
}
