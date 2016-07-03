using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class ConfigGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Config> Configs { get; set; }
    }
}
