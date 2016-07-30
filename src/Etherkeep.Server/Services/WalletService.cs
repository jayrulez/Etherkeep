using Etherkeep.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etherkeep.Server.Services.Models;
using Etherkeep.Data;

namespace Etherkeep.Server.Services
{
    public class WalletService : IWalletService
    {
        ApplicationDbContext dbContext;
        public WalletService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public WalletModel CreateWallet()
        {
            return new WalletModel()
            {
                Id = Guid.NewGuid().ToString()
            };
        }

        public WalletAddressModel CreateWalletAddress(WalletModel wallet)
        {
            return new WalletAddressModel()
            {
            };
        }

        public WalletModel FindWalletById(string id)
        {
            return new WalletModel()
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
