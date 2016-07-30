using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class Config
    {
        public string Id { get; set; }
        public string ConfigGroupId { get; set; }
        public string ConfigType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }

        public virtual ConfigGroup ConfigGroup { get; set; }
        public virtual ICollection<ConfigOption> ConfigOptions { get; set; }
    }
}
