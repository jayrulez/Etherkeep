using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class CountryCurrency
    {
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }

        public virtual Country Country { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
