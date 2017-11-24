using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankOfItaly.ExchangeRate.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankOfItaly.ExchangeRate.Client.Tests
{
    [TestClass()]
    public class RestServiceTests
    {

        private DateTime GetValidRatesDate()
        {
            var date = DateTime.Now.AddDays(-1);
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(-1);
            }
            return date;
        }

        private DateTime GetDateOfPreviousMonth()
        {
            return DateTime.Now.AddMonths(-1);
        }

        private DateTime GetDateOfPreviousYear()
        {
            return DateTime.Now.AddYears(-1);
        }

        private static void AssertFile(string filePath)
        {
            Assert.IsTrue(File.Exists(filePath));
            Assert.IsTrue(new FileInfo(filePath).Length > 0);
        }

        private string GetTemporaryFilePath(string fileName)
        {
            var filePath = Path.Combine(Path.GetTempPath(), fileName);
            if (File.Exists(filePath)) { File.Delete(filePath); }
            return filePath;
        }

        private static void AssertValidRatesResponse(Model.RatesResponse rates)
        {
            Assert.IsNotNull(rates);
            Assert.IsTrue(rates.Rates.Length > 0);
        }

        private static void AssertValidCurrenciesResponse(Model.CurrenciesResponse currencies)
        {
            Assert.IsNotNull(currencies);
            Assert.IsTrue(currencies.Currencies.Length > 0);
        }
        private static void AssertValidLatestRatesResponse(Model.LatestRatesResponse rates)
        {
            Assert.IsNotNull(rates);
            Assert.IsTrue(rates.LatestRates.Length > 0);
        }

        private static void AssertTaskRatesResponse(Task<Model.RatesResponse> task)
        {
            task.Wait();
            Assert.IsTrue(task.IsCompleted);
            if (task.IsCompleted)
            {
                AssertValidRatesResponse(task.Result);
            }
        }

        private static void AssertTaskDownloadFile(string filePath, Task task)
        {
            task.Wait();
            Assert.IsTrue(task.IsCompleted);
            if (task.IsCompleted) { AssertFile(filePath); }
        }

        [TestMethod()]
        public void RestServiceTest()
        {
            var service = RestServiceFactory.Create();
            Assert.IsNotNull(service);
        }

        [TestMethod()]
        public void RestServiceTest1()
        {
            var customEndpointBaseUrl = "http://www.google.it"; 
            var service = RestServiceFactory.Create(customEndpointBaseUrl);
            Assert.IsNotNull(service);
            Assert.IsTrue(customEndpointBaseUrl.Equals(service.EndpointBaseUrl));
        }

        [TestMethod()]
        public void GetCurrenciesTest()
        {
            var service = RestServiceFactory.Create();
            var currencies = service.GetCurrencies();
            AssertValidCurrenciesResponse(currencies);
        }

        [TestMethod()]
        public void GetCurrenciesAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var task = service.GetCurrenciesAsync();
            task.Wait();
            Assert.IsTrue(task.IsCompleted);
            if (task.IsCompleted)
            {
                AssertValidCurrenciesResponse(task.Result);
            }
            
        }

        [TestMethod()]
        public void GetLatestRatesTest()
        {
            var service = RestServiceFactory.Create();
            var rates = service.GetLatestRates();
            AssertValidLatestRatesResponse(rates);
        }


        [TestMethod()]
        public void GetLatestRatesAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var task = service.GetLatestRatesAsync();
            task.Wait();
            Assert.IsTrue(task.IsCompleted);
            if (task.IsCompleted)
            {
                AssertValidLatestRatesResponse(task.Result);
            }
        }

        [TestMethod()]
        public void DownloadLatestRatesFileTest()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadLatestRatesFile.csv");
            service.DownloadLatestRatesFile(Model.FileFormat.Csv, filePath);
            AssertFile(filePath);
        }


        [TestMethod()]
        public void DownloadLatestRatesFileAsync()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadLatestRatesFileAsync.csv");
            var task = service.DownloadLatestRatesFileAsync(Model.FileFormat.Csv, filePath);
            AssertTaskDownloadFile(filePath, task);
        }

        [TestMethod()]
        public void GetDailyRatesTest()
        {
            var service = RestServiceFactory.Create();
            var rates = service.GetDailyRates(GetValidRatesDate(), "EUR");
            AssertValidRatesResponse(rates);
        }

        [TestMethod()]
        public void GetDailyRatesAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var task = service.GetDailyRatesAsync(GetValidRatesDate(), "EUR");
            AssertTaskRatesResponse(task);
        }

        [TestMethod()]
        public void DownloadDailyRatesFileTestCsv()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadDailyRatesFileTest.csv");
            service.DownloadDailyRatesFile(Model.FileFormat.Csv, filePath, GetValidRatesDate(), "EUR");
            AssertFile(filePath);
        }

        [TestMethod()]
        public void DownloadDailyRatesFileTestPdf()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadDailyRatesFileTest.pdf");
            service.DownloadDailyRatesFile(Model.FileFormat.Pdf, filePath, GetValidRatesDate(), "EUR");
            AssertFile(filePath);
        }

        [TestMethod()]
        public void DownloadDailyRatesFileTestXls()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadDailyRatesFileTest.xls");
            service.DownloadDailyRatesFile(Model.FileFormat.Xls, filePath, DateTime.Now, "EUR");
            AssertFile(filePath);
        }

        [TestMethod()]
        public void DownloadDailyRatesFileAsync()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadDailyRatesFileTestAsync.csv");
            var task = service.DownloadDailyRatesFileAsync(Model.FileFormat.Csv, filePath, DateTime.Now, "EUR");
            AssertTaskDownloadFile(filePath, task);
        }

        [TestMethod()]
        public void GetMonthlyAverageRatesTest()
        {
            var service = RestServiceFactory.Create();
            var date = GetDateOfPreviousMonth();
            var rates = service.GetMonthlyAverageRates(date.Month, date.Year, "EUR");
            AssertValidRatesResponse(rates);
        }


        [TestMethod()]
        public void GetMonthlyAverageRatesAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var date = GetDateOfPreviousMonth();
            var task = service.GetMonthlyAverageRatesAsync(date.Month, date.Year, "EUR");
            AssertTaskRatesResponse(task);
        }


        [TestMethod()]
        public void DownloadMonthlyAverageRatesFileTest()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadMonthlyAverageRatesFileTest.csv");
            var date = GetDateOfPreviousMonth();
            service.DownloadMonthlyAverageRatesFile(Model.FileFormat.Csv, filePath, date.Month, date.Year, "EUR");
            AssertFile(filePath);
        }

        [TestMethod()]
        public void DownloadMonthlyAverageRatesFileAsync()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadMonthlyAverageRatesFileAsync.csv");
            var date = GetDateOfPreviousMonth();
            var task = service.DownloadMonthlyAverageRatesFileAsync(Model.FileFormat.Csv, filePath, date.Month, date.Year, "EUR");
            AssertTaskDownloadFile(filePath, task);
        }

        [TestMethod()]
        public void GetAnnualAverageRatesTest()
        {
            var service = RestServiceFactory.Create();
            var date = GetDateOfPreviousYear();
            var rates = service.GetAnnualAverageRates(date.Year, "EUR");
            AssertValidRatesResponse(rates);
        }

        [TestMethod()]
        public void GetAnnualAverageRatesAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var date = GetDateOfPreviousYear();
            var task = service.GetAnnualAverageRatesAsync(date.Year, "EUR");
            AssertTaskRatesResponse(task);
        }

        [TestMethod()]
        public void DownloadAnnualAverageRatesFileTest()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadAnnualAverageRatesFileTest.csv");
            var date = GetDateOfPreviousYear();
            service.DownloadAnnualAverageRatesFile(Model.FileFormat.Csv, filePath, date.Year, "EUR");
            AssertFile(filePath);
        }

        [TestMethod()]
        public void DownloadAnnualAverageRatesFileAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadAnnualAverageRatesFileAsyncTest.csv");
            var date = GetDateOfPreviousYear();
            var task = service.DownloadAnnualAverageRatesFileAsync(Model.FileFormat.Csv, filePath, date.Year, "EUR");
            AssertTaskDownloadFile(filePath, task);
        }

        [TestMethod()]
        public void GetDailyTimeSeriesTest()
        {
            var service = RestServiceFactory.Create();
            var endDate  = GetDateOfPreviousMonth();
            var startDate = endDate.AddDays(-60);
            var rates = service.GetDailyTimeSeries(startDate, endDate, "GBP", "EUR");
            AssertValidRatesResponse(rates);
        }

        [TestMethod()]
        public void GetDailyTimeSeriesAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddDays(-60);
            var task = service.GetDailyTimeSeriesAsync(startDate, endDate, "GBP", "EUR");
            AssertTaskRatesResponse(task);
        }

        [TestMethod()]
        public void DownloadDailyTimeSeriesFileTest()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadDailyTimeSeriesFileTest.csv");
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddDays(-60);
            service.DownloadDailyTimeSeriesFile(Model.FileFormat.Csv, filePath, startDate, endDate, "GBP", "EUR");
            AssertFile(filePath);
        }

        [TestMethod()]
        public void DownloadDailyTimeSeriesFileAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadDailyTimeSeriesFileAsyncTest.csv");
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddDays(-60);
            var task = service.DownloadDailyTimeSeriesFileAsync(Model.FileFormat.Csv, filePath, startDate, endDate, "GBP", "EUR");
            AssertTaskDownloadFile(filePath, task);
        }

        [TestMethod()]
        public void GetMonthlyTimeSeriesTest()
        {
            var service = RestServiceFactory.Create();
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddMonths(-8);
            var rates = service.GetMonthlyTimeSeries(startDate.Month, startDate.Year, endDate.Month, endDate.Year, "GBP", "EUR");
            AssertValidRatesResponse(rates);
        }

        [TestMethod()]
        public void GetMonthlyTimeSeriesAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddMonths(-8);
            var task = service.GetMonthlyTimeSeriesAsync(startDate.Month, startDate.Year, endDate.Month, endDate.Year, "GBP", "EUR");
            AssertTaskRatesResponse(task);
        }

        [TestMethod()]
        public void DownloadMonthlyTimeSeriesFileTest()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadMonthlyTimeSeriesFileTest.csv");
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddMonths(-8);
            service.DownloadMonthlyTimeSeriesFile(Model.FileFormat.Csv, filePath, startDate.Month, startDate.Year, endDate.Month, endDate.Year, "GBP", "EUR");
            AssertFile(filePath);
        }

        [TestMethod()]
        public void DownloadMonthlyTimeSeriesFileAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadMonthlyTimeSeriesFileAsyncTest.csv");
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddMonths(-8);
            var task = service.DownloadMonthlyTimeSeriesFileAsync(Model.FileFormat.Csv, filePath, startDate.Month, startDate.Year, endDate.Month, endDate.Year, "GBP", "EUR");
            AssertTaskDownloadFile(filePath, task);
        }

        [TestMethod()]
        public void GetAnnualTimeSeriesTest()
        {
            var service = RestServiceFactory.Create();
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddYears(-10);
            var rates = service.GetAnnualTimeSeries(startDate.Year, endDate.Year, "GBP", "EUR");
            AssertValidRatesResponse(rates);
        }

        [TestMethod()]
        public void GetAnnualTimeSeriesAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddYears(-10);
            var task = service.GetAnnualTimeSeriesAsync(startDate.Year, endDate.Year, "GBP", "EUR");
            AssertTaskRatesResponse(task);
        }

        [TestMethod()]
        public void DownloadAnnualTimeSeriesFileTest()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadAnnualTimeSeriesFileTest.csv");
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddYears(-10);
            service.DownloadAnnualTimeSeriesFile(Model.FileFormat.Csv, filePath, startDate.Year, endDate.Year, "GBP", "EUR");
            AssertFile(filePath);
        }

        [TestMethod()]
        public void DownloadAnnualTimeSeriesFileAsyncTest()
        {
            var service = RestServiceFactory.Create();
            var filePath = GetTemporaryFilePath("DownloadAnnualTimeSeriesFileAsyncTest.csv");
            var endDate = GetDateOfPreviousMonth();
            var startDate = endDate.AddYears(-10);
            var task = service.DownloadAnnualTimeSeriesFileAsync(Model.FileFormat.Csv, filePath, startDate.Year, endDate.Year, "GBP", "EUR");
            AssertTaskDownloadFile(filePath, task);
        }
    }
}