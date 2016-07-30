using Etherkeep.Data;
using Etherkeep.Data.Entities;
using Etherkeep.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Managers
{
    public class UserWalletManager : IUserWalletManager
    {
        private ApplicationDbContext DbContext;
        private IWalletService WalletService;
        private ILogger Logger;

        public UserWalletManager(ApplicationDbContext dbContext, IWalletService walletService, ILoggerFactory loggerFactory)
        {
            this.DbContext = dbContext;
            this.WalletService = walletService;
            this.Logger = loggerFactory.CreateLogger<UserWalletManager>();
        }

        public async Task<UserWallet> CreateWalletAsync(User user, string label = null)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                var walletModel = WalletService.CreateWallet();

                var wallet = new UserWallet()
                {
                    Id = walletModel.Id,
                    Label = !string.IsNullOrEmpty(label) ? label : Guid.NewGuid().ToString(),
                    Balance = 0
                };

                user.Wallets.Add(wallet);

                var primaryWallet = await DbContext.UserPrimaryWallets.FirstOrDefaultAsync(e => e.UserId == user.Id);

                if (primaryWallet == null)
                {
                    user.PrimaryWallet = new UserPrimaryWallet()
                    {
                        Wallet = wallet
                    };
                }

                DbContext.Entry<User>(user).State = EntityState.Modified;

                await DbContext.SaveChangesAsync();

                return wallet;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);

                throw ex;
            }
        }
    }
}
