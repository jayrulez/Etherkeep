using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class UserPrimaryEmailAddress
    {
        public Guid UserId { get; set; }
        public string Address { get; set; }

        public virtual User User { get; set; }
        public virtual EmailAddress EmailAddress { get; set; }
    }
}
