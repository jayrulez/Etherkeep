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
        public string Carrier { get; set; }
        public Guid UserId { get; set; }
        public bool Verified { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public string Canonical
        {
            get
            {
                return CountryCallingCode + AreaCode + SubscriberNumber;
            }
        }

        public virtual User User { get; set; }

        public virtual UserPrimaryMobileNumber PrimaryMobileNumber { get; set; }
    }
}
