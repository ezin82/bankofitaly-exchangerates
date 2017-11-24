using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfItaly.ExchangeRate.Client
{
    /// <summary>
    /// Factory 
    /// </summary>
    public sealed class RestServiceFactory
    {
        private RestServiceFactory() { }

        /// <summary>
        /// Restituisce una nuova istanza del client REST 
        /// </summary>
        /// <returns></returns>
        public static IRestService Create()
        {
            return new RestService();
        }

        /// <summary>
        /// Restituisce una nuova istanza del client REST 
        /// </summary>
        /// <param name="endpointBaseUrl">Url dell'endpoint di base se diverso da quello predefinito</param>
        /// <returns></returns>
        public static IRestService Create(string endpointBaseUrl)
        {
            return new RestService(endpointBaseUrl);
        }
    }
}
