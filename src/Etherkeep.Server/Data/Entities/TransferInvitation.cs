using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;

namespace Etherkeep.Server.Data.Entities
{
    public class TransferInvitation
    {
        public int Id { get; set; }
        public TransferType Type { get; set; }
        public Guid InvokerUserId { get; set; }
        public TransferInvitationTargetType TargetType { get; set; }
        public string TargetIdentity { get; set; }

        public string CurrencyCode { get; set; }
        public double Amount { get; set; }
        public double ExchangeRate { get; set; }
        public double FeeAmount { get; set; }
        public double TotalCharge { get; set; }
        
        public double TokenAmount { get; set; }

        public TransferStatus Status { get; set; }
        public bool Processed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User Invoker { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual SuspenseWallet SuspenseWallet { get; set; }
        public virtual ICollection<TransferInvitationFee> TransferInvitationFees { get; set; }
        public virtual ICollection<TransferInvitationMessage> TransferInvitationMessages { get; set; }
    }
}
