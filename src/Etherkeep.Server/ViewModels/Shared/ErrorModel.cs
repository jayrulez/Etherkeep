using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Etherkeep.Server.ViewModels.Shared {
    public class ErrorViewModel
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
