﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Etherkeep.Accounts.ViewModels.Authorization {
    public class AuthorizeViewModel {
        [Display(Name = "Application")]
        public string ApplicationName { get; set; }

        [BindNever]
        public string RequestId { get; set; }

        [Display(Name = "Scope")]
        public string Scope { get; set; }
    }
}
