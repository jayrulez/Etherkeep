using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.ViewModels.Account
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
