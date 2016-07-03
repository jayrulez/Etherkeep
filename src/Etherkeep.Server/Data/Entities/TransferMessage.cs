using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class TransferMessage
    {
        public int Id { get; set; }
        public int TransferId { get; set; }
        public Guid UserId { get; set; }
        public bool Read { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Transfer Transfer { get; set; }
        public virtual User User { get; set; }
    }
}
