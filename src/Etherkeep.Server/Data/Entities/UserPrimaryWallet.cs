using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class UserPrimaryWallet
    {
        public Guid UserId { get; set; }
        public string WalletId { get; set; }

        public virtual User User { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
