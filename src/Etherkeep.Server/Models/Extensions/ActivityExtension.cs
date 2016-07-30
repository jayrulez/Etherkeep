using Etherkeep.Server.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Etherkeep.Server.Models.Account;
using Etherkeep.Data.Entities;

namespace Etherkeep.Server.Models.Extensions
{
    public static partial class Extensions
    {
        public static ActivityModel ToModel(this Activity source)
        {
            var destination = new ActivityModel();

            return destination;
        }

        public static ICollection<ActivityModel> ToModel(this IEnumerable<Activity> source)
        {
            var destination = new Collection<ActivityModel>();

            if(source != null)
            {
                foreach(var item in source)
                {
                    destination.Add(item.ToModel());
                }
            }

            return destination;
        }
    }
}
