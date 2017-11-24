using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client.Model
{
    public sealed class FileFormat
    {
        // Define values here.
        public static readonly FileFormat Json = new FileFormat("application/json");
        public static readonly FileFormat Csv = new FileFormat("text/csv");
        public static readonly FileFormat Pdf = new FileFormat("application/pdf");
        public static readonly FileFormat Xls = new FileFormat("application/vnd.ms-excel");

        internal readonly string Accept;

        // Constructor is private: values are defined within this class only!
        private FileFormat(string accept)
        {
            Accept = accept;
        }
    }
}
