using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client.Model
{
    public class BaseRate
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("isoCode")]
        public string IsoCode { get; set; }

        [JsonProperty("referenceDate")]
        public string ReferenceDate { get; set; }

        [JsonProperty("uicCode")]
        public string UicCode { get; set; }

        [JsonProperty("usdExchangeConvention")]
        public string UsdExchangeConvention { get; set; }

        [JsonProperty("usdExchangeConventionCode")]
        public string UsdExchangeConventionCode { get; set; }
    }
}
