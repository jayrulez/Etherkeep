using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class SettingOption
    {
        public int Id { get; set; }
        public string SettingId { get; set; }
        public string Value { get; set; }

        public virtual Setting Setting { get; set; }
    }
}
