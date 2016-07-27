using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class MobileNumber
    {
        public string CountryCallingCode { get; set; }
        public string AreaCode { get; set; }
        public string SubscriberNumber { get; set; }

        public string FullMobileNumber { get { return string.Concat(CountryCallingCode, AreaCode, SubscriberNumber); } }
        public Guid UserId { get; set; }
        public bool Verified { get; set; }

        public virtual User User { get; set; }
        public virtual UserPrimaryMobileNumber PrimaryMobileNumber { get; set; }
    }
}
