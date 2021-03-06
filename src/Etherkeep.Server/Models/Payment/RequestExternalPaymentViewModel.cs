﻿using Etherkeep.Data.Enums;
using Newtonsoft.Json;

namespace Etherkeep.Server.Models.Payment
{
    public class RequestExternalPaymentModel
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
