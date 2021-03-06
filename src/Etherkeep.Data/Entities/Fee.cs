﻿using Etherkeep.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class Fee
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public FeeType Type { get; set; }
        public double Value { get; set; }
        public double RangeStart { get; set; }
        public double RangeEnd {get; set;}
        public bool Enabled { get; set; }


        public virtual Currency Currency { get; set; }
    }
}
