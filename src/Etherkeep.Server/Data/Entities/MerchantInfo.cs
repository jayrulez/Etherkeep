using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class MerchantInfo
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
