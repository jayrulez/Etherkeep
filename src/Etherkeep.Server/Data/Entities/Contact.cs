using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public ContactType Type { get; set; }
        public Guid ContactId { get; set; }
        public DateTime LastActivity { get; set; }

        public virtual User User { get; set; }
        public virtual User Subject { get; set; }
    }
}
