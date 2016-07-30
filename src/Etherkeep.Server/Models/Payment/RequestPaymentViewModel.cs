using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Models.Payment
{
    public class RequestPaymentModel
    {
        [JsonProperty("receiver_id")]
        public Guid ReceiverId { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}
