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
        public static CurrencyModel ToModel(this Currency source)
        {
            if(source == null)
            {
                return null;
            }

            var destination = new CurrencyModel();

            destination.Code = source.Code;
            destination.Name = source.Name;
            destination.Symbol = source.Symbol;
            destination.Precision = source.Precision;
            destination.Template = source.Template;

            return destination;
        }

        public static ICollection<CurrencyModel> ToModel(this ICollection<Currency> source)
        {
            if (source == null)
            {
                return null;
            }

            var destination = new Collection<CurrencyModel>();

            foreach(var item in source)
            {
                destination.Add(item.ToModel());
            }

            return destination;
        }
    }
}
