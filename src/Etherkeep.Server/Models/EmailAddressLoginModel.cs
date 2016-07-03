using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Models
{
    public class EmailAddressLoginModel : BaseLoginModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
