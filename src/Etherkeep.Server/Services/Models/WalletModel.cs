using Newtonsoft.Json;

namespace Etherkeep.Server.Services.Models
{
    public class WalletModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
        public string Data { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("confirmedBalance")]
        public double ConfirmedBalance { get; set; }
    }
}