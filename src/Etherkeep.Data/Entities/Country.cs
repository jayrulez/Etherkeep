﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }

        public Currency Currency { get; set; }
        public virtual ICollection<LoginAttempt> LoginAttempts { get; set; }
    }
}
