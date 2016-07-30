using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Precision { get; set; }
        public string Template { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<MerchantBill> MerchantBills { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PaymentRequest> PaymentRequests { get; set; }
        public virtual ICollection<ExternalPayment> ExternalPayments { get; set; }
        public virtual ICollection<ExternalPaymentRequest> ExternalPaymentRequests { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
