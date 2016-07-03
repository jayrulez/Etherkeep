using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.ViewModels
{
    public class EmailLoginViewModel
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Scope { get; set; }
    }
}
