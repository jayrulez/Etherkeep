using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class WalletAddress
    {
        public string Address { get; set; }
        public string WalletId { get; set; }
        public double Balance { get; set; }

        public virtual Wallet Wallet { get; set; }
    }
}
