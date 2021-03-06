﻿using System;
using System.Collections.Generic;

namespace Etherkeep.Data.Entities
{
    public class UserWallet
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public string Passphrase { get; set; }
        public string Label { get; set; }
        public double Balance { get; set; }
        public double ConfirmedBalance { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserWalletAddress> WalletAddresses { get; set; }
        public virtual UserPrimaryWallet PrimaryWallet { get; set; }
    }
}
