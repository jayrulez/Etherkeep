using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class PaymentRequest
    {
        public int Id { get; set; }
        public int? ExternalPaymentRequestId { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string CurrencyCode { get; set; }
        public double Amount { get; set; }
        public PaymentRequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual ExternalPaymentRequest ExternalPaymentRequest { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
}
