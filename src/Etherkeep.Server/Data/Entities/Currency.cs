using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Precision { get; set; }
        public string Template { get; set; }

        public virtual ICollection<CountryCurrency> CountryCurrencies { get; set; }
        public virtual ICollection<Transfer> TargetTransfers { get; set; }
        public virtual ICollection<Transfer> InvokerTransfers { get; set; }
        public virtual ICollection<TransferInvitation> TargetTransferInvitations { get; set; }
        public virtual ICollection<TransferInvitation> InvokerTransferInvitations { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
