using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        public TransferType Type { get; set; }
        public Guid InvokerUserId { get; set; }
        public Guid TargetUserId { get; set; }
        public string InvokerCurrencyCode { get; set; }
        public double InvokerAmount { get; set; }
        public double FeeAmount { get; set; }
        public double TotalCharge { get; set; }
        public string TargetCurrencyCode { get; set; }
        public double TargetAmount { get; set; }
        public double ExchangeRate { get; set; }
        public TransferStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User Invoker { get; set; }
        public virtual User Target { get; set; }
        public virtual Currency InvokerCurrency { get; set; }
        public virtual Currency TargetCurrency { get; set; }
        public virtual ICollection<TransferFee> TransferFees { get; set; }
        public virtual ICollection<TransferMessage> TransferMessages { get; set; }
    }
}
