using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Enums
{
    public enum PaymentRequestStatus
    {
        Pending,
        Cancelled,
        Rejected,
        Accepted
    }
}
