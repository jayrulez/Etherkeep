using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class EmailAddress
    {
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public bool Verified { get; set; }

        public virtual User User { get; set; }
        public virtual UserPrimaryEmailAddress PrimaryEmailAddress { get; set; }
    }
}
