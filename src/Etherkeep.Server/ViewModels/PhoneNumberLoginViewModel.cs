using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.ViewModels
{
    public class PhoneNumberLoginViewModel
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        [Required]
        public string CountryCallingCode { get; set; }

        [Required]
        public string AreaCode { get; set; }

        [Required]
        public string SubscriberNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public string Scope { get; set; }
    }
}
