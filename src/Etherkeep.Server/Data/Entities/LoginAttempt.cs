using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class LoginAttempt
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string IpAddress { get; set; }
        public string CountryCode { get; set; }
        public string GeoLocation { get; set; }
        public DateTime TimeStamp { get; set; }
        public LoginAttemptStatus Status { get; set; }

        public virtual User User { get; set; }
        public virtual Country Country { get; set; }
    }
}
