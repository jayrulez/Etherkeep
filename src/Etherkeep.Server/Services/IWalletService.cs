using Etherkeep.Server.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Services
{
    public interface IWalletService
    {
        Task<WalletModel> CreateWalletAsync(string passphrase, string label);

        WalletModel FindWalletById(string id);

        WalletAddressModel CreateWalletAddress(string id);
    }
}
