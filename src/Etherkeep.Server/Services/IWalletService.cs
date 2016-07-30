using Etherkeep.Server.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Services
{
    public interface IWalletService
    {
        WalletModel CreateWallet();

        WalletModel FindWalletById(string id);

        WalletAddressModel CreateWalletAddress(WalletModel wallet);
    }
}
