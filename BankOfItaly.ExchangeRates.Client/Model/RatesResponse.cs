using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client.Model
{
    public class RatesResponse
    {
        public ResultsInfo ResultsInfo { get; set; }
        public Rate[] Rates { get; set; }
    }
}
