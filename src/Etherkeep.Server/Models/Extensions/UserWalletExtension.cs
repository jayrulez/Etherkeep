using Etherkeep.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Models.Extensions
{
    public static partial class Extensions
    {
        public static UserWalletModel ToModel(this UserWallet source)
        {
            if(source == null)
            {
                return null;
            }

            var destination = new UserWalletModel();

            destination.Id = source.Id;
            destination.Balance = source.Balance;

            return destination;
        }
    }
}
