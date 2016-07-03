using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CountryCurrency> CountryCurrencies { get; set; }
        public virtual ICollection<LoginAttempt> LoginAttempts { get; set; }
    }
}
