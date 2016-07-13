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
        public Guid SenderUserId { get; set; }
        public Guid ReceiverUserId { get; set; }

        public string CurrencyCode { get; set; }
        public double Amount { get; set; }
        public double ExchangeRate { get; set; }
        public double FeeAmount { get; set; }
        public double TotalCharge { get; set; }
        
        public double TokenAmount { get; set; }
        public TransferStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TransactionId { get; set; }

        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual ICollection<TransferFee> TransferFees { get; set; }
        public virtual ICollection<TransferMessage> TransferMessages { get; set; }
    }
}
