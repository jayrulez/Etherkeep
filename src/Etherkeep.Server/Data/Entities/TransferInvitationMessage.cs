using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class TransferInvitationMessage
    {
        public int Id { get; set; }
        public int TransferInvitationId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual TransferInvitation TransferInvitation { get; set; }
        public virtual User User { get; set; }
    }
}
