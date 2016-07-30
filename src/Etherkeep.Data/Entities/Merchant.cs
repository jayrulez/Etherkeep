using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class Merchant
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<MerchantWallet> Wallets { get; set; }

        public virtual ICollection<MerchantBill> Bills { get; set; }
    }
}
