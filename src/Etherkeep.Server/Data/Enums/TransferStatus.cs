using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Enums
{
    public enum TransferStatus
    {
        Pending,
        Accepted,
        Completed,
        Canceled,
        Rejected
    }
}
