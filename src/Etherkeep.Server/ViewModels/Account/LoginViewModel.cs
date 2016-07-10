using Etherkeep.Server.ViewModels.Account;
using System.ComponentModel.DataAnnotations;

namespace Etherkeep.Server.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        public LoginMode LoginMode { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
        
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        public string CountryCallingCode { get; set; }
        
        public string AreaCode { get; set; }
        
        public string SubscriberNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Scope { get; set; }

        [Display(Name = "Remember me?")]
        public bool Persistent { get; set; }
    }
}
