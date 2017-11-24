using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client.Model
{
    public class Currency
    {
        [JsonProperty("countries")]
        public Country[] Countries { get; set; }

        [JsonProperty("graph")]
        public bool Graph { get; set; }

        [JsonProperty("isoCode")]
        public string IsoCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
