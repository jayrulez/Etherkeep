using Etherkeep.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class MerchantBill
    {
        public int Id { get; set; }

        public int MerchantId { get; set; }

        public string Address { get; set; }
        public string CurrencyCode { get; set; }
        public double Amount { get; set; }

        public virtual Merchant Merchant { get; set; }

        public virtual Currency Currency { get; set; }
        public MerchantBillStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual MerchantWalletAddress WalletAddress { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
