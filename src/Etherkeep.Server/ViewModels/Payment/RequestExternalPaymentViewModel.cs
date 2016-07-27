using Etherkeep.Server.Data.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.ViewModels.Payment
{
    public class RequestExternalPaymentViewModel
    {
        [JsonProperty("receiver_type")]
        public ReceiverType ReceiverType { get; set; }

        [JsonProperty("receiver")]
        public string Receiver { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}
