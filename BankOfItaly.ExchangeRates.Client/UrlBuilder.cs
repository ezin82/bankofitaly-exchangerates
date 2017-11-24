using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankOfItaly.ExchangeRate.Client.Model;

namespace BankOfItaly.ExchangeRate.Client
{
    internal class UrlBuilder
    {
        /// <summary>
        /// Default endpoint base url
        /// </summary>
        internal const string EndpointBaseUrl = "https://tassidicambio.bancaditalia.it/terzevalute-wf-web/rest/v1.0";


        #region rest service methods patterns

        internal const string LatestRates = "/latestRates?";

        internal const string DailyRates = "/dailyRates?referenceDate={0:yyyy-MM-dd}&currencyIsoCode={1}";

        internal const string MonthlyAverageRates = "/monthlyAverageRates?month={0}&year={1}&currencyIsoCode={2}";

        internal const string AnnualAverageRates = "/annualAverageRates?year={0}&currencyIsoCode={1}";

        internal const string DailyTimeSeries = "/dailyTimeSeries?startDate={0:yyyy-MM-dd}&endDate={1:yyyy-MM-dd}&baseCurrencyIsoCode={2}&currencyIsoCode={3}";

        internal const string MonthlyTimeSeries = "/monthlyTimeSeries?startMonth={0}&startYear={1}&endMonth={2}&endYear={3}&baseCurrencyIsoCode={4}&currencyIsoCode={5}";

        internal const string AnnualTimeSeries = "/annualTimeSeries?startYear={0}&endYear={1}&baseCurrencyIsoCode={2}&currencyIsoCode={3}";

        internal const string Currencies = "/currencies?";

        #endregion

        #region optional querystring parameters
        internal const string BaseCurrencyIsoCode = "baseCurrencyIsoCode={0}";

        internal const string Language = "lang={0}";
        #endregion

        private static void AppendBaseCurrencyIsoCode(string[] baseCurrencyIsoCode, StringBuilder b)
        {
            if (baseCurrencyIsoCode != null)
            {
                foreach (var item in baseCurrencyIsoCode)
                {
                    AppendSeparator(b);
                    b.AppendFormat(BaseCurrencyIsoCode, item);
                }
            }
        }

        private static void AppendSeparator(StringBuilder b)
        {
            b.Append('&');
        }

        private static void AppendLanguage(Language language, StringBuilder b)
        {
            b.AppendFormat(Language, language.ToString().ToLower());
        }

        private static void AppendLanguageAndBaseCurrencyIsoCode(Language language, string[] baseCurrencyIsoCode, StringBuilder b)
        {
            AppendSeparator(b);
            AppendLanguage(language, b);
            AppendBaseCurrencyIsoCode(baseCurrencyIsoCode, b);
        }

        internal static string GetCurrenciesRequestUrl(string endpointBaseUrl, Language language)
        {
            var b = new StringBuilder();
            b.Append(endpointBaseUrl);
            b.Append(Currencies);
            AppendLanguage(language, b);
            return b.ToString();
        }

        internal static string GetLatestRatesRequestUrl(string endpointBaseUrl, Language language)
        {
            var b = new StringBuilder();
            b.Append(endpointBaseUrl);
            b.Append(LatestRates);
            AppendLanguage(language, b);
            return b.ToString();
        }

        internal static string GetDailyRatesRequestUrl(string endpointBaseUrl, DateTime referenceDate, string currencyIsoCode, Language language, string[] baseCurrencyIsoCode)
        {
            var b = new StringBuilder();
            b.Append(endpointBaseUrl);
            b.AppendFormat(DailyRates, referenceDate, currencyIsoCode);
            AppendLanguageAndBaseCurrencyIsoCode(language, baseCurrencyIsoCode, b);
            return b.ToString();
        }

        internal static string GetMonthlyAverageRatesRequestUrl(string endpointBaseUrl, int month, int year, string currencyIsoCode, Language language, string[] baseCurrencyIsoCode)
        {
            var b = new StringBuilder();
            b.Append(endpointBaseUrl);
            b.AppendFormat(MonthlyAverageRates, month, year, currencyIsoCode);
            AppendLanguageAndBaseCurrencyIsoCode(language, baseCurrencyIsoCode, b);
            return b.ToString();
        }

        internal static string GetAnnualAverageRatesRequestUrl(string endpointBaseUrl, int year, string currencyIsoCode, Language language, string[] baseCurrencyIsoCode)
        {
            var b = new StringBuilder();
            b.Append(endpointBaseUrl);
            b.AppendFormat(AnnualAverageRates, year, currencyIsoCode);
            AppendLanguageAndBaseCurrencyIsoCode(language, baseCurrencyIsoCode, b);
            return b.ToString();
        }

        internal static string GetDailyTimeSeriesRequestUrl(string endpointBaseUrl, DateTime startDate, DateTime endDate, string baseCurrencyIsoCode, string currencyIsoCode, Language language)
        {
            var b = new StringBuilder();
            b.Append(endpointBaseUrl);
            b.AppendFormat(DailyTimeSeries, startDate, endDate, baseCurrencyIsoCode, currencyIsoCode);
            AppendSeparator(b);
            AppendLanguage(language, b);
            return b.ToString();
        }

        internal static string GetMonthlyTimeSeriesRequestUrl(string endpointBaseUrl, int startMonth, int startYear, int endMonth, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language)
        {
            var b = new StringBuilder();
            b.Append(endpointBaseUrl);
            b.AppendFormat(MonthlyTimeSeries, startMonth, startYear, endMonth, endYear, baseCurrencyIsoCode, currencyIsoCode);
            AppendSeparator(b);
            AppendLanguage(language, b);
            return b.ToString();
        }

        internal static string GetAnnualTimeSeriesRequestUrl(string endpointBaseUrl, int startYear, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language)
        {
            var b = new StringBuilder();
            b.Append(endpointBaseUrl);
            b.AppendFormat(AnnualTimeSeries, startYear, endYear, baseCurrencyIsoCode, currencyIsoCode);
            AppendSeparator(b);
            AppendLanguage(language, b);
            return b.ToString();
        }
    }
}
