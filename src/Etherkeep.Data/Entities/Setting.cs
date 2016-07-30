using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class Setting
    {
        public string Id { get; set; }
        public string SettingGroupId { get; set; }
        public string SettingType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }

        public virtual SettingGroup SettingGroup { get; set; }
        public virtual ICollection<SettingOption> SettingOptions { get; set; }
    }
}
