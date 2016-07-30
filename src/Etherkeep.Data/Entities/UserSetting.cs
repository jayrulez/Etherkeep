using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class UserSetting
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
