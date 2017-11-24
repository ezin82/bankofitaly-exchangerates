using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client.Model
{
    public class LatestRatesResponse
    {
        [JsonProperty("latestRates")]
        public LatestRate[] LatestRates { get; set; }

        [JsonProperty("resultsInfo")]
        public ResultsInfo ResultsInfo { get; set; }
    }
}
