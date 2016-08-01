using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Constants
{
    public class ActivityType
    {
        public const string Payment                = "payment";
        public const string ExternalPayment        = "external_payment";
        public const string PaymentRequest         = "payment_request";
        public const string ExternalPaymentRequest = "external_payment_request";
    }
}
