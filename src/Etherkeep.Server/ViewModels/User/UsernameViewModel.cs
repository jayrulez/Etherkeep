using Etherkeep.Server.ViewModels.Account;
using Etherkeep.Server.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace Etherkeep.Server.ViewModels.User
{
    public class UsernameViewModel
    {
        [Required]
        public IdentityType IdentityType { get; set; }
        
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        public string CountryCallingCode { get; set; }
        
        public string AreaCode { get; set; }
        
        public string SubscriberNumber { get; set; }
    }
}
