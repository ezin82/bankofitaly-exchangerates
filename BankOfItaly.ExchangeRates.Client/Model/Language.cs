using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client.Model
{
    public sealed class Language
    {
        public static readonly Language It = new Language("it");
        public static readonly Language En = new Language("en");

        private readonly string code;
        private Language(string code)
        {
            this.code = code;
        }
        public override string ToString()
        {
            return this.code;
        }
    }
}
