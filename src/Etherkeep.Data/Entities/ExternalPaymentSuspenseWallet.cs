using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class ExternalPaymentSuspenseWallet : ISuspenseWallet
    {
        public string Id { get; set; }

        public int ExternalPaymentId { get; set; }

        public string Label { get; set; }

        public double Balance { get; set; }

        public virtual ExternalPayment ExternalPayment { get; set; }
    }
}
