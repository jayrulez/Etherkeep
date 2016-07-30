using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class MerchantWallet
    {
        public string Id { get; set; }
        public int MerchantId { get; set; }
        public string Label { get; set; }
        public double Balance { get; set; }

        public virtual Merchant Merchant { get; set; }
        public virtual ICollection<MerchantWalletAddress> WalletAddresses { get; set; }
    }
}
