using System;
using System.Collections.Generic;

namespace Etherkeep.Server.Data.Entities
{
    public class UserWallet
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public string Label { get; set; }
        public double Balance { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserWalletAddress> UserWalletAddresses { get; set; }
    }
}
