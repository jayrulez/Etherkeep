using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class PaymentSuspenseWallet : ISuspenseWallet
    {
        public string Id { get; set; }

        public int PaymentId { get; set; }

        public string Label { get; set; }

        public double Balance { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
