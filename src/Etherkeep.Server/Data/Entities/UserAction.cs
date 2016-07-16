using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class UserAction
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ActionType { get; set; }
        public string Data { get; set; }

        public virtual User User { get; set; }
    }
}
