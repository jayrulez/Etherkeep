using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class UserPrimaryEmailAddress
    {
        public Guid UserId { get; set; }
        public string PrimaryEmailAddress { get; set; }

        public User User { get; set; }
        public EmailAddress EmailAddress { get; set; }
    }
}
