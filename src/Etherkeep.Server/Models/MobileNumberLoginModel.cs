using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Models
{
    public class MobileNumberLoginModel : BaseLoginModel
    {
        [Required]
        public string CountryCallingCode { get; set; }

        [Required]
        public string AreaCode { get; set; }

        [Required]
        public string SubscriberNumber { get; set; }
    }
}
