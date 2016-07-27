using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Services
{
    public interface IExchangeRateService
    {
        double GetExchangeRate(string CurrencyCode);
    }
}
