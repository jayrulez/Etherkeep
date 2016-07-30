using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Etherkeep.Accounts.ViewModels.Shared {
    public class ErrorViewModel
    {
        [JsonProperty("error")]
        [Display(Name = "Error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        [Display(Name = "Description")]
        public string ErrorDescription { get; set; }
    }
}
