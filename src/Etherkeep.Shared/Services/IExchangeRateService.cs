using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Shared.Services
{
    public interface IExchangeRateService
    {
        double GetExchangeRate(string CurrencyCode);
    }
}
