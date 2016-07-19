using Caricoin.Core.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class ExternalPayment
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public ExternalPaymentReceiverType ReceiverType { get; set; }
        public string Receiver { get; set; }
        public double Amount { get; set; }
        public ExternalPaymentStatus Status { get; set; }

        public virtual User Sender { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
