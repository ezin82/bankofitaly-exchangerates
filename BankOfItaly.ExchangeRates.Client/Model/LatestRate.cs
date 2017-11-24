using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client.Model
{
    public class LatestRate : BaseRate
    {
        [JsonProperty("usdRate")]
        public string UsdRate { get; set; }

        [JsonProperty("eurRate")]
        public string EurRate { get; set; }
    }
}
