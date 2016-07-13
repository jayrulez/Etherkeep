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
        public string InvokerCurrencyCode { get; set; }
        public double InvokerAmount { get; set; }
        public double InvokerExchangeRate { get; set; }
        public TransferInvitationTargetType TargetType { get; set; }
        public string TargetIdentity { get; set; }
        public string TargetCurrencyCode { get; set; }
        public double TargetAmount { get; set; }
        public double TargetExchangeRate { get; set; }

        /*The token amount*/
        public double Amount { get; set; }

        public TransferStatus Status { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User Invoker { get; set; }
        public virtual Currency InvokerCurrency { get; set; }
        public virtual Currency TargetCurrency { get; set; }
        public virtual SuspenseWallet SuspenseWallet { get; set; }
        public virtual ICollection<TransferInvitationFee> TransferInvitationFees { get; set; }
        public virtual ICollection<TransferInvitationMessage> TransferInvitationMessages { get; set; }
    }
}
