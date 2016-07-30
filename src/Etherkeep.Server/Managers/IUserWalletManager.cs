using Etherkeep.Data.Entities;
using System.Threading.Tasks;

namespace Etherkeep.Server.Managers
{
    public interface IUserWalletManager
    {
        Task<UserWallet> CreateWalletAsync(User user, string label = null);
    }
}
