using System.ComponentModel.DataAnnotations;

namespace Etherkeep.Server.Models
{
    public class EmailAddressRegistrationModel : BaseRegistrationModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
