using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client.Model
{
    public class Rate : BaseRate
    {
        [JsonProperty("avgRate")]
        public string AvgRate { get; set; }
    }
}
