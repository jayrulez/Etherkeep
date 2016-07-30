using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class UserPrimaryMobileNumber
    {
        public Guid UserId { get; set; }
        public string CountryCallingCode { get; set; }
        public string AreaCode { get; set; }
        public string SubscriberNumber { get; set; }

        public virtual User User { get; set; }
        public virtual MobileNumber MobileNumber { get; set; }
    }
}
