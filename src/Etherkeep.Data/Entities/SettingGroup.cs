using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class SettingGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }
    }
}
