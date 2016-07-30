using Etherkeep.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Etherkeep.Server.ViewModels.Account;
using Etherkeep.Data.Entities;

namespace Etherkeep.Server.ViewModels.Extensions
{
    public static partial class Extensions
    {
        public static ActivityViewModel ToViewModel(this Activity source)
        {
            var destination = new ActivityViewModel();

            return destination;
        }

        public static ICollection<ActivityViewModel> ToViewModel(this IEnumerable<Activity> source)
        {
            var destination = new Collection<ActivityViewModel>();

            if(source != null)
            {
                foreach(var item in source)
                {
                    destination.Add(item.ToViewModel());
                }
            }

            return destination;
        }
    }
}
