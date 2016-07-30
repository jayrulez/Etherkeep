using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public interface ISuspenseWallet
    {
        string Id { get; set; }
        string Label { get; set; }
        double Balance { get; set; }
    }
}
