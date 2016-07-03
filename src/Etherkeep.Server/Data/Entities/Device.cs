using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class Device
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }

        public virtual User User { get; set; }
    }
}
