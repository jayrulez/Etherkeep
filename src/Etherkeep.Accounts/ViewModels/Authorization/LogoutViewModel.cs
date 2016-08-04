using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Etherkeep.Accounts.ViewModels.Authorization {
    public class LogoutViewModel {
        [BindNever]
        public string RequestId { get; set; }
    }
}
