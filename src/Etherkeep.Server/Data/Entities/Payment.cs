using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int? PaymentRequestId { get; set; }
        public int? ExternalPaymentId { get; set; }
        public int? InvoiceId { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string CurrencyCode { get; set; }
        public double ExchangeRate { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }
        public double Total { get; set; }
        public double Tokens { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual PaymentRequest PaymentRequest { get; set; }
        public virtual ExternalPayment ExternalPayment { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
}
