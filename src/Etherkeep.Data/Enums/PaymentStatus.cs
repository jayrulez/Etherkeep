using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Enums
{
    public enum PaymentStatus
    {
        Pending,
        Cancelled,
        Rejected,
        Accepted,
        Completed
    }
}
