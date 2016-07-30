using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Etherkeep.Server.Models.Shared {
    public class ErrorModel
    {
        [JsonProperty("error")]
        [Display(Name = "Error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        [Display(Name = "Description")]
        public string ErrorDescription { get; set; }
    }
}
