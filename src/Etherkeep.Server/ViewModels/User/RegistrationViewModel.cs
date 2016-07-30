using Etherkeep.Server.ViewModels.Account;
using System.ComponentModel.DataAnnotations;

namespace Etherkeep.Server.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required]
        public IdentityType IdentityType { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
        
        public string CountryCallingCode { get; set; }
        
        public string AreaCode { get; set; }
        
        public string SubscriberNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
