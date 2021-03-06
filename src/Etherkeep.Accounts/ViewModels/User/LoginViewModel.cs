﻿using System.ComponentModel.DataAnnotations;

namespace Etherkeep.Accounts.ViewModels.User
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Scope { get; set; }

        [Display(Name = "Remember me?")]
        public bool Persistent { get; set; }
    }
}
