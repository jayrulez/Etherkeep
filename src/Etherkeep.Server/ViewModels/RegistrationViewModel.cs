using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public RegisterMode RegisterMode { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
        
        public string CountryCallingCode { get; set; }
        
        public string AreaCode { get; set; }
        
        public string SubscriberNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
