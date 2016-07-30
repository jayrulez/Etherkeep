using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Models.User
{
    public class ResetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
