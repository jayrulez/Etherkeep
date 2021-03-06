﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class ConfigOption
    {
        public int Id { get; set; }
        public string ConfigId { get; set; }
        public string Value { get; set; }

        public virtual Config Config { get; set; }
    }
}
