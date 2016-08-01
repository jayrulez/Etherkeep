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
        private ApplicationDbContext _dbContext;
        private IWalletService _walletService;
        private ILogger _logger;

        public UserWalletManager(ApplicationDbContext dbContext, IWalletService walletService, ILoggerFactory loggerFactory)
        {
            this._dbContext     = dbContext;
            this._walletService = walletService;
            this._logger        = loggerFactory.CreateLogger<UserWalletManager>();
        }

        public async Task<UserWallet> CreateWalletAsync(User user, string label = null)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                var walletModel = _walletService.CreateWallet();

                var wallet = new UserWallet()
                {
                    Id = walletModel.Id,
                    Label = !string.IsNullOrEmpty(label) ? label : Guid.NewGuid().ToString(),
                    Balance = 0
                };

                user.Wallets.Add(wallet);

                var primaryWallet = await _dbContext.UserPrimaryWallets.FirstOrDefaultAsync(e => e.UserId == user.Id);

                if (primaryWallet == null)
                {
                    user.PrimaryWallet = new UserPrimaryWallet()
                    {
                        Wallet = wallet
                    };
                }

                _dbContext.Entry<User>(user).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();

                return wallet;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                throw ex;
            }
        }
    }
}
