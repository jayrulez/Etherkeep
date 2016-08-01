using Etherkeep.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Models.Extensions
{
    public static partial class Extensions
    {
        public static UserWalletAddressModel ToModel(this UserWalletAddress source)
        {
            if (source == null)
            {
                return null;
            }

            var destination = new UserWalletAddressModel();

            destination.Address = source.Address;
            destination.WalletId = source.WalletId;
            destination.Balance = source.Balance;

            return destination;
        }

        public static ICollection<UserWalletAddressModel> ToModel(this ICollection<UserWalletAddress> source)
        {
            if (source == null)
            {
                return null;
            }

            var destination = new Collection<UserWalletAddressModel>();

            foreach(var item in source)
            {
                destination.Add(item.ToModel());
            }

            return destination;
        }
    }
}
