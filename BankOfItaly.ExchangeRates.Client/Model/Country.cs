using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client.Model
{
    public class Country
    {
        [JsonProperty("countryISO")]
        public string CountryISO { get; set; }

        [JsonProperty("currencyISO")]
        public string CurrencyISO { get; set; }

        [JsonProperty("country")]
        public string PurpleCountry { get; set; }

        [JsonProperty("validityEndDate")]
        public string ValidityEndDate { get; set; }

        [JsonProperty("validityStartDate")]
        public string ValidityStartDate { get; set; }
    }
}
