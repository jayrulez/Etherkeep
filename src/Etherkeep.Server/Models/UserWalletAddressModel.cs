using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Models
{
    public class UserWalletAddressModel
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("wallet_id")]
        public string WalletId { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }
    }
}
