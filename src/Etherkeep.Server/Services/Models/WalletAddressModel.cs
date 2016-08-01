using Newtonsoft.Json;

namespace Etherkeep.Server.Services.Models
{
    public class WalletAddressModel
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("chain")]
        public int Chain { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
        
        [JsonProperty("redeemScript")]
        public string RedeemScript { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("confirmedBalance")]
        public double ConfirmedBalance { get; set; }

        [JsonProperty("received")]
        public double Received { get; set; }

        [JsonProperty("sent")]
        public double Sent { get; set; }

        [JsonProperty("txCount")]
        public int TxCount { get; set; }

        public string Data { get; set; }
    }
}
