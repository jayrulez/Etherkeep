using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public LoginMode LoginMode { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        public string CountryCallingCode { get; set; }
        
        public string AreaCode { get; set; }
        
        public string SubscriberNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public string Scope { get; set; }
    }
}
