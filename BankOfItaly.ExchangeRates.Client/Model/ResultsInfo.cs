using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client.Model
{
    public class ResultsInfo
    {
        [JsonProperty("notice")]
        public string Notice { get; set; }

        [JsonProperty("timezoneReference")]
        public string TimezoneReference { get; set; }

        [JsonProperty("totalRecords")]
        public long TotalRecords { get; set; }
    }
}
