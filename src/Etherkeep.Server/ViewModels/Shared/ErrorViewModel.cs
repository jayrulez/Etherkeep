using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Etherkeep.Server.ViewModels.Shared {
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
