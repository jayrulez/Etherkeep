using Etherkeep.Data;
using Etherkeep.Data.Entities;
using Etherkeep.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            this._dbContext = dbContext;
            this._walletService = walletService;
            this._logger = loggerFactory.CreateLogger<UserWalletManager>();
        }

        public async Task<UserWallet> CreateWalletAsync(User user, string passphrase, string label)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrEmpty(label))
            {
                label = $"{user.Id.ToString()}_{Guid.NewGuid().ToString()}";
            }

            try
            {
                var walletModel = await _walletService.CreateWalletAsync(passphrase, label);

                var wallet = new UserWallet()
                {
                    Id = walletModel.Id,
                    Passphrase = passphrase,
                    Label = label,
                    Balance = 0,
                    CreatedAt = DateTime.UtcNow,
                    Data = walletModel.Data
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
