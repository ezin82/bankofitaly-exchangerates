using BankOfItaly.ExchangeRate.Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankOfItaly.ExchangeRate.Client
{
    internal class RestService : IRestService
    {
        private string endpointBaseUrl = null;
        public string EndpointBaseUrl { get { return endpointBaseUrl; } }

        public int RequestTimeout { get; set; } = 10000;

        internal RestService() : this(UrlBuilder.EndpointBaseUrl)
        {
        }

        internal RestService(string endpointBaseUrl)
        {
            this.endpointBaseUrl = endpointBaseUrl;
        }


        #region web requests

        private T Get<T>(string requestUri)
        {
            HttpWebRequest request = CreateWebRequest(requestUri);
            request.Accept = FileFormat.Json.Accept;
            var response = request.GetResponse();
            string json = null;
            using (StreamReader s = new StreamReader(response.GetResponseStream()))
            {
                json = s.ReadToEnd();                
            }
            T obj = JsonConvert.DeserializeObject<T>(json, JsonConverter.Settings);
            return obj;
        }

        private void Download(string requestUri, FileFormat fileFormat, string outputFilePath)
        {
            HttpWebRequest request = CreateWebRequest(requestUri);
            request.Accept = fileFormat.Accept;
            var response = request.GetResponse();

            using (var input = response.GetResponseStream())
            {
                using (var fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int size = input.Read(buffer, 0, buffer.Length);
                    while (size > 0)
                    {
                        fileStream.Write(buffer, 0, size);
                        size = input.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        private HttpWebRequest CreateWebRequest(string requestUri)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = "GET";
            request.Timeout = RequestTimeout;
            return request;
        }
        #endregion

        #region currencies
        public CurrenciesResponse GetCurrencies(Language language = Language.It)
        {
            string requestUrl = UrlBuilder.GetCurrenciesRequestUrl(endpointBaseUrl, language);
            var response = Get<CurrenciesResponse>(requestUrl);
            return response;
        }

        public Task<CurrenciesResponse> GetCurrenciesAsync(Language language = Language.It)
        {
            return Task.Factory.StartNew(() => { return GetCurrencies(language); });
        }

        #endregion

        #region latestRates
        public LatestRatesResponse GetLatestRates(Language language = Language.It)
        {
            string requestUrl = UrlBuilder.GetLatestRatesRequestUrl(endpointBaseUrl, language);
            var response = Get<LatestRatesResponse>(requestUrl);
            return response;
        }
        public Task<LatestRatesResponse> GetLatestRatesAsync(Language language = Language.It)
        {
            return Task.Factory.StartNew(() => { return GetLatestRates(language); });
        }

        public void DownloadLatestRatesFile(FileFormat fileFormat, string outputFilePath, Language language = Language.It)
        {
            string requestUrl = UrlBuilder.GetLatestRatesRequestUrl(endpointBaseUrl, language);
            Download(requestUrl, fileFormat, outputFilePath);
        }

        public Task DownloadLatestRatesFileAsync(FileFormat fileFormat, string outputFilePath, Language language = Language.It)
        {
            return Task.Factory.StartNew(() => { DownloadLatestRatesFile(fileFormat, outputFilePath, language); });
        }
        #endregion

        #region dailyRates

        public RatesResponse GetDailyRates(DateTime referenceDate, string currencyIsoCode, Language language = Language.It,  string[] baseCurrencyIsoCode = null)
        {
            string requestUrl = UrlBuilder.GetDailyRatesRequestUrl(endpointBaseUrl, referenceDate, currencyIsoCode, language, baseCurrencyIsoCode);
            var response = Get<RatesResponse>(requestUrl);
            return response;
        }

        public Task<RatesResponse> GetDailyRatesAsync(DateTime referenceDate, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            return Task.Factory.StartNew(() => { return GetDailyRates(referenceDate, currencyIsoCode, language, baseCurrencyIsoCode); });
        }


        public void DownloadDailyRatesFile(FileFormat fileFormat, string outputFilePath, DateTime referenceDate, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            string requestUrl = UrlBuilder.GetDailyRatesRequestUrl(endpointBaseUrl, referenceDate, currencyIsoCode, language, baseCurrencyIsoCode);
            Download(requestUrl, fileFormat, outputFilePath);
        }

        public Task DownloadDailyRatesFileAsync(FileFormat fileFormat, string outputFilePath, DateTime referenceDate, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            return Task.Factory.StartNew(() => { DownloadDailyRatesFile(fileFormat, outputFilePath, referenceDate, currencyIsoCode, language, baseCurrencyIsoCode); });
        }


        #endregion

        #region monthlyAverageRates
        public RatesResponse GetMonthlyAverageRates(int month, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            string requestUrl = UrlBuilder.GetMonthlyAverageRatesRequestUrl(endpointBaseUrl, month, year, currencyIsoCode, language, baseCurrencyIsoCode);
            var response = Get<RatesResponse>(requestUrl);
            return response;
        }

        public Task<RatesResponse> GetMonthlyAverageRatesAsync(int month, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            return Task.Factory.StartNew(() => { return GetMonthlyAverageRates(month, year, currencyIsoCode, language, baseCurrencyIsoCode); });
        }

        public void DownloadMonthlyAverageRatesFile(FileFormat fileFormat, string outputFilePath, int month, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            string requestUrl = UrlBuilder.GetMonthlyAverageRatesRequestUrl(endpointBaseUrl, month, year, currencyIsoCode, language, baseCurrencyIsoCode);
            Download(requestUrl, fileFormat, outputFilePath);
        }

        public Task DownloadMonthlyAverageRatesFileAsync(FileFormat fileFormat, string outputFilePath,  int month, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            return Task.Factory.StartNew(() => { DownloadMonthlyAverageRatesFile(fileFormat, outputFilePath, month, year, currencyIsoCode, language, baseCurrencyIsoCode); });
        }

        #endregion

        #region annualAverageRates
        public RatesResponse GetAnnualAverageRates(int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            string requestUrl = UrlBuilder.GetAnnualAverageRatesRequestUrl(endpointBaseUrl, year, currencyIsoCode, language, baseCurrencyIsoCode);
            var response = Get<RatesResponse>(requestUrl);
            return response;
        }

        public Task<RatesResponse> GetAnnualAverageRatesAsync(int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            return Task.Factory.StartNew(() => { return GetAnnualAverageRates(year, currencyIsoCode, language, baseCurrencyIsoCode); });
        }

        public void DownloadAnnualAverageRatesFile(FileFormat fileFormat, string outputFilePath, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            string requestUrl = UrlBuilder.GetAnnualAverageRatesRequestUrl(endpointBaseUrl, year, currencyIsoCode, language, baseCurrencyIsoCode);
            Download(requestUrl, fileFormat, outputFilePath);
        }

        public Task DownloadAnnualAverageRatesFileAsync(FileFormat fileFormat, string outputFilePath, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null)
        {
            return Task.Factory.StartNew(() => { DownloadAnnualAverageRatesFile(fileFormat, outputFilePath, year, currencyIsoCode, language, baseCurrencyIsoCode); });
        }
        #endregion

        #region dailyTimeSeries
        public RatesResponse GetDailyTimeSeries(DateTime startDate, DateTime endDate, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            string requestUrl = UrlBuilder.GetDailyTimeSeriesRequestUrl(endpointBaseUrl, startDate, endDate, baseCurrencyIsoCode, currencyIsoCode, language);
            var response = Get<RatesResponse>(requestUrl);
            return response;
        }

        public Task<RatesResponse> GetDailyTimeSeriesAsync(DateTime startDate, DateTime endDate, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            return Task.Factory.StartNew(() => { return GetDailyTimeSeries(startDate, endDate, baseCurrencyIsoCode, currencyIsoCode, language); });
        }

        public void DownloadDailyTimeSeriesFile(FileFormat fileFormat, string outputFilePath, DateTime startDate, DateTime endDate, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            string requestUrl = UrlBuilder.GetDailyTimeSeriesRequestUrl(endpointBaseUrl, startDate, endDate, baseCurrencyIsoCode, currencyIsoCode, language);
            Download(requestUrl, fileFormat, outputFilePath);
        }

        public Task DownloadDailyTimeSeriesFileAsync(FileFormat fileFormat, string outputFilePath, DateTime startDate, DateTime endDate, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            return Task.Factory.StartNew(() => { DownloadDailyTimeSeriesFile(fileFormat, outputFilePath, startDate, endDate, baseCurrencyIsoCode, currencyIsoCode, language); });
        }
        #endregion

        #region monthlyTimeSeries
        public RatesResponse GetMonthlyTimeSeries(int startMonth, int startYear, int endMonth, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            string requestUrl = UrlBuilder.GetMonthlyTimeSeriesRequestUrl(endpointBaseUrl, startMonth, startYear, endMonth, endYear, baseCurrencyIsoCode, currencyIsoCode, language);
            var response = Get<RatesResponse>(requestUrl);
            return response;
        }

        public Task<RatesResponse> GetMonthlyTimeSeriesAsync(int startMonth, int startYear, int endMonth, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            return Task.Factory.StartNew(() => { return GetMonthlyTimeSeries(startMonth, startYear, endMonth, endYear, baseCurrencyIsoCode, currencyIsoCode, language); });
        }

        public void DownloadMonthlyTimeSeriesFile(FileFormat fileFormat, string outputFilePath, int startMonth, int startYear, int endMonth, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            string requestUrl = UrlBuilder.GetMonthlyTimeSeriesRequestUrl(endpointBaseUrl, startMonth, startYear, endMonth, endYear, baseCurrencyIsoCode, currencyIsoCode, language);
            Download(requestUrl, fileFormat, outputFilePath);
        }

        public Task DownloadMonthlyTimeSeriesFileAsync(FileFormat fileFormat, string outputFilePath, int startMonth, int startYear, int endMonth, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            return Task.Factory.StartNew(() => { DownloadMonthlyTimeSeriesFile(fileFormat, outputFilePath, startMonth, startYear, endMonth, endYear, baseCurrencyIsoCode, currencyIsoCode, language); });
        }
        #endregion

        #region annualTimeSeries
        public RatesResponse GetAnnualTimeSeries(int startYear, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            string requestUrl = UrlBuilder.GetAnnualTimeSeriesRequestUrl(endpointBaseUrl, startYear, endYear, baseCurrencyIsoCode, currencyIsoCode, language);
            var response = Get<RatesResponse>(requestUrl);
            return response;
        }

        public Task<RatesResponse> GetAnnualTimeSeriesAsync(int startYear, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            return Task.Factory.StartNew(() => { return GetAnnualTimeSeries(startYear, endYear, baseCurrencyIsoCode, currencyIsoCode, language); });
        }

        public void DownloadAnnualTimeSeriesFile(FileFormat fileFormat, string outputFilePath, int startYear, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            string requestUrl = UrlBuilder.GetAnnualTimeSeriesRequestUrl(endpointBaseUrl, startYear, endYear, baseCurrencyIsoCode, currencyIsoCode, language);
            Download(requestUrl, fileFormat, outputFilePath);
        }

        public Task DownloadAnnualTimeSeriesFileAsync(FileFormat fileFormat, string outputFilePath, int startYear, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It)
        {
            return Task.Factory.StartNew(() => { DownloadAnnualTimeSeriesFile(fileFormat, outputFilePath, startYear, endYear, baseCurrencyIsoCode, currencyIsoCode, language); });
        }
        #endregion
    }
}
