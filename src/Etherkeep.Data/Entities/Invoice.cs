using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string WalletAddress { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
