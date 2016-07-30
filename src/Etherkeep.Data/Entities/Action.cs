using Etherkeep.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ActionType { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ActionParameter> Parameters { get; set; }
    }
}
