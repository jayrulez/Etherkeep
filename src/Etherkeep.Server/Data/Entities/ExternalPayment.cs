using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class ExternalPayment
    {
        public int Id { get; set; }
        public Guid SenderId { get; set; }
        public ExternalPaymentReceiverType ReceiverType { get; set; }
        public string Receiver { get; set; }
        public string CurrencyCode { get; set; }
        public double ExchangeRate { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }
        public double Total { get; set; }
        public double Tokens { get; set; }
        public ExternalPaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual User Sender { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
