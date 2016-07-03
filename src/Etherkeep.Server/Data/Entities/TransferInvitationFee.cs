using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class TransferInvitationFee
    {
        public int TransferInvitationId { get; set; }
        public int FeeId { get; set; }
        public FeeType FeeType { get; set; }
        public double FeeValue { get; set; }
        public double Amount { get; set; }

        public virtual TransferInvitation TransferInvitation { get; set; }
        public virtual Fee Fee { get; set; }
    }
}
