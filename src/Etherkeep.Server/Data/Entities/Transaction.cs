using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int? TransferId { get; set; }
        public string Hash { get; set; }
        public int Confirmations { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Transfer Transfer { get; set; }
    }
}
