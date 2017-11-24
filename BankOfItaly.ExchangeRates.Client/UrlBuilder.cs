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

        internal const string DailyRates = "/dailyRates?referenceDate={0:yyyy-MM-dd}&currencyIsoCode={1}&lang={2}";

        internal const string MonthlyAverageRates = "/monthlyAverageRates?month={0}&year={1}&currencyIsoCode={2}&lang={3}";

        internal const string AnnualAverageRates = "/annualAverageRates?year={0}&currencyIsoCode={1}&lang={2}";

        internal const string DailyTimeSeries = "/dailyTimeSeries?startDate={0:yyyy-MM-dd}&endDate={1:yyyy-MM-dd}&baseCurrencyIsoCode={2}&currencyIsoCode={3}&lang={4}";

        internal const string MonthlyTimeSeries = "/monthlyTimeSeries?startMonth={0}&startYear={1}&endMonth={2}&endYear={3}&baseCurrencyIsoCode={4}&currencyIsoCode={5}&lang={6}";

        internal const string AnnualTimeSeries = "/annualTimeSeries?startYear={0}&endYear={1}&baseCurrencyIsoCode={2}&currencyIsoCode={3}&lang={4}";

        internal const string Currencies = "/currencies?";

        #endregion

        #region optional querystring parameters
        internal const string BaseCurrencyIsoCode = "baseCurrencyIsoCode={0}";

        #endregion

        private static void AppendBaseCurrencyIsoCode(string[] baseCurrencyIsoCode, StringBuilder requestUrl)
        {
            if (baseCurrencyIsoCode != null)
            {
                foreach (var item in baseCurrencyIsoCode)
                {
                    requestUrl.Append('&');
                    requestUrl.AppendFormat(BaseCurrencyIsoCode, item);
                }
            }
        }


        internal static string GetCurrenciesRequestUrl(string endpointBaseUrl, Language language)
        {
            var requestUrl = new StringBuilder();
            requestUrl.Append(endpointBaseUrl);
            requestUrl.AppendFormat(Currencies, language ?? Language.It);
            return requestUrl.ToString();
        }

        internal static string GetLatestRatesRequestUrl(string endpointBaseUrl, Language language)
        {
            var requestUrl = new StringBuilder();
            requestUrl.Append(endpointBaseUrl);
            requestUrl.AppendFormat(LatestRates, language ?? Language.It);
            return requestUrl.ToString();
        }

        internal static string GetDailyRatesRequestUrl(string endpointBaseUrl, DateTime referenceDate, string currencyIsoCode, Language language, string[] baseCurrencyIsoCode)
        {
            var requestUrl = new StringBuilder();
            requestUrl.Append(endpointBaseUrl);
            requestUrl.AppendFormat(DailyRates, referenceDate, currencyIsoCode, language ?? Language.It);
            AppendBaseCurrencyIsoCode(baseCurrencyIsoCode, requestUrl);
            return requestUrl.ToString();
        }

        internal static string GetMonthlyAverageRatesRequestUrl(string endpointBaseUrl, int month, int year, string currencyIsoCode, Language language, string[] baseCurrencyIsoCode)
        {
            var requestUrl = new StringBuilder();
            requestUrl.Append(endpointBaseUrl);
            requestUrl.AppendFormat(MonthlyAverageRates, month, year, currencyIsoCode, language ?? Language.It);
            AppendBaseCurrencyIsoCode(baseCurrencyIsoCode, requestUrl);
            return requestUrl.ToString();
        }

        internal static string GetAnnualAverageRatesRequestUrl(string endpointBaseUrl, int year, string currencyIsoCode, Language language, string[] baseCurrencyIsoCode)
        {
            var requestUrl = new StringBuilder();
            requestUrl.Append(endpointBaseUrl);
            requestUrl.AppendFormat(AnnualAverageRates, year, currencyIsoCode, language ?? Language.It);
            AppendBaseCurrencyIsoCode(baseCurrencyIsoCode, requestUrl);
            return requestUrl.ToString();
        }

        internal static string GetDailyTimeSeriesRequestUrl(string endpointBaseUrl, DateTime startDate, DateTime endDate, string baseCurrencyIsoCode, string currencyIsoCode, Language language)
        {
            var requestUrl = new StringBuilder();
            requestUrl.Append(endpointBaseUrl);
            requestUrl.AppendFormat(DailyTimeSeries, startDate, endDate, baseCurrencyIsoCode, currencyIsoCode, language ?? Language.It);
            return requestUrl.ToString();
        }

        internal static string GetMonthlyTimeSeriesRequestUrl(string endpointBaseUrl, int startMonth, int startYear, int endMonth, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language)
        {
            var requestUrl = new StringBuilder();
            requestUrl.Append(endpointBaseUrl);
            requestUrl.AppendFormat(MonthlyTimeSeries, startMonth, startYear, endMonth, endYear, baseCurrencyIsoCode, currencyIsoCode, language ?? Language.It);
            return requestUrl.ToString();
        }

        internal static string GetAnnualTimeSeriesRequestUrl(string endpointBaseUrl, int startYear, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language)
        {
            var requestUrl = new StringBuilder();
            requestUrl.Append(endpointBaseUrl);
            requestUrl.AppendFormat(AnnualTimeSeries, startYear, endYear, baseCurrencyIsoCode, currencyIsoCode, language ?? Language.It);
            return requestUrl.ToString();
        }
    }
}
