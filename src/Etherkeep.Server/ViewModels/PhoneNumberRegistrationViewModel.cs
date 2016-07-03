using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.ViewModels
{
    public class PhoneNumberRegistrationViewModel
    {
        [Required]
        public string CountryCallingCode { get; set; }

        [Required]
        public string AreaCode { get; set; }

        [Required]
        public string SubscriberNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
