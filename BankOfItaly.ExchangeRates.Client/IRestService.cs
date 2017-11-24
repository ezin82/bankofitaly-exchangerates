using System;
using System.Threading.Tasks;
using BankOfItaly.ExchangeRate.Client.Model;

namespace BankOfItaly.ExchangeRate.Client
{
    /// <summary>
    /// Tassi di Cambio – REST API (Versione 1.0) 
    /// </summary>
    public interface IRestService
    {
        #region properties
        /// <summary>
        /// Il nuovo dominio base per i servizi A2A è: https://tassidicambio.bancaditalia.it/terzevalute-wf-web/rest/v1.0 
        /// </summary>
        string EndpointBaseUrl { get; }

        /// <summary>
        /// Timeout per le request http. Valore predefinito 10.000 ms
        /// </summary>
        int RequestTimeout { get; set; }
        #endregion

        #region currencies
        /// <summary>
        /// Restituisce l’elenco di tutte le valute , comprese quelle non più quotate.
        /// </summary>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <returns></returns>
        CurrenciesResponse GetCurrencies(Language language = Language.It);

        /// <summary>
        /// Restituisce l’elenco di tutte le valute , comprese quelle non più quotate.
        /// </summary>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <returns></returns>
        Task<CurrenciesResponse> GetCurrenciesAsync(Language language = Language.It);

        #endregion

        #region latestRates
        /// <summary>
        /// Fornisce i cambi, contro Euro e contro dollaro Usa, dell'ultimo giorno per cui sono disponibili le quotazioni tra tutte le valute in corso.
        /// </summary>
        /// <param name="language">Stringa identificativa della lingua in cui si desidera ottenere i dati: può valere  “it” o “en” case insensitive. Se il parametro non viene specificato, o valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <returns></returns>
        LatestRatesResponse GetLatestRates(Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi, contro Euro e contro dollaro Usa, dell'ultimo giorno per cui sono disponibili le quotazioni tra tutte le valute in corso.
        /// </summary>
        /// <param name="language">Stringa identificativa della lingua in cui si desidera ottenere i dati: può valere  “it” o “en” case insensitive. Se il parametro non viene specificato, o valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <returns></returns>
        Task<LatestRatesResponse> GetLatestRatesAsync(Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi, contro Euro e contro dollaro Usa, dell'ultimo giorno per cui sono disponibili le quotazioni tra tutte le valute in corso.
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="language">Stringa identificativa della lingua in cui si desidera ottenere i dati: può valere  “it” o “en” case insensitive. Se il parametro non viene specificato, o valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        void DownloadLatestRatesFile(FileFormat fileFormat, string outputFilePath, Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi, contro Euro e contro dollaro Usa, dell'ultimo giorno per cui sono disponibili le quotazioni tra tutte le valute in corso.
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="language">Stringa identificativa della lingua in cui si desidera ottenere i dati: può valere  “it” o “en” case insensitive. Se il parametro non viene specificato, o valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        Task DownloadLatestRatesFileAsync(FileFormat fileFormat, string outputFilePath, Language language = Language.It);

        #endregion


        #region dailyRates
        /// <summary>
        /// Fornisce i cambi giornalieri per una specifica data, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più valute richieste, che siano valide e per le quali sia disponibile la quotazione per la data selezionata. E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per la data e le valute richieste, non esistano quotazioni, il servizio restituisce l'elenco vuoto con un messaggio informativo.  
        /// </summary>
        /// <param name="referenceDate">Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se  la data inserita non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore. </param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Nel caso di più valute il parametro sarà ripetuto.  Se il parametro  non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati. Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <returns></returns>
        RatesResponse GetDailyRates(DateTime referenceDate, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);

        /// <summary>
        /// Fornisce i cambi giornalieri per una specifica data, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più valute richieste, che siano valide e per le quali sia disponibile la quotazione per la data selezionata. E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per la data e le valute richieste, non esistano quotazioni, il servizio restituisce l'elenco vuoto con un messaggio informativo.   
        /// </summary>
        /// <param name="referenceDate">Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se  la data inserita non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore. </param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Nel caso di più valute il parametro sarà ripetuto.  Se il parametro  non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati. Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <returns></returns>
        Task<RatesResponse> GetDailyRatesAsync(DateTime referenceDate, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);

        /// <summary>
        /// Fornisce i cambi giornalieri per una specifica data, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più valute richieste, che siano valide e per le quali sia disponibile la quotazione per la data selezionata. E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per la data e le valute richieste, non esistano quotazioni, il servizio restituisce l'elenco vuoto con un messaggio informativo.  
        /// </summary>
        /// <param name="referenceDate">Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se  la data inserita non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore. </param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Nel caso di più valute il parametro sarà ripetuto.  Se il parametro  non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati. Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        void DownloadDailyRatesFile(FileFormat fileFormat, string outputFilePath, DateTime referenceDate, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);

        /// <summary>
        /// Fornisce i cambi giornalieri per una specifica data, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più valute richieste, che siano valide e per le quali sia disponibile la quotazione per la data selezionata. E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per la data e le valute richieste, non esistano quotazioni, il servizio restituisce l'elenco vuoto con un messaggio informativo.  
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="referenceDate">Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se  la data inserita non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore. </param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Nel caso di più valute il parametro sarà ripetuto.  Se il parametro  non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati. Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <returns></returns>
        Task DownloadDailyRatesFileAsync(FileFormat fileFormat, string outputFilePath, DateTime referenceDate, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);
        #endregion


        #region monthlyAverageRates
        /// <summary>
        /// Fornisce i cambi medi mensili per uno specifico mese/anno, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più  valute richieste, che siano valide e per le quali sia disponibile la quotazione. E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per il mese e le valute richieste, non esistano quotazioni, il servizio restituirà un elenco vuoto. 
        /// </summary>
        /// <param name="month">Mese per cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato un valore non consentito, il servizio restituirà un errore http 400 ed un  messaggio indicante la necessità del parametro con un valore compreso tra 1 e 12. </param>
        /// <param name="year">Anno per cui si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se per la coppia mese/anno inserita non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Nel caso di più valute il parametro sarà ripetuto.  Se il parametro  non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati. Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore</param>
        /// <returns></returns>
        RatesResponse GetMonthlyAverageRates(int month, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);

        /// <summary>
        /// Fornisce i cambi medi mensili per uno specifico mese/anno, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più  valute richieste, che siano valide e per le quali sia disponibile la quotazione. E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per il mese e le valute richieste, non esistano quotazioni, il servizio restituirà un elenco vuoto. 
        /// </summary>
        /// <param name="month">Mese per cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato un valore non consentito, il servizio restituirà un errore http 400 ed un  messaggio indicante la necessità del parametro con un valore compreso tra 1 e 12. </param>
        /// <param name="year">Anno per cui si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se per la coppia mese/anno inserita non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Nel caso di più valute il parametro sarà ripetuto.  Se il parametro  non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati. Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore</param>
        /// <returns></returns>
        Task<RatesResponse> GetMonthlyAverageRatesAsync(int month, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);

        /// <summary>
        /// Fornisce i cambi medi mensili per uno specifico mese/anno, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più  valute richieste, che siano valide e per le quali sia disponibile la quotazione. E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per il mese e le valute richieste, non esistano quotazioni, il servizio restituirà un elenco vuoto. 
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="month">Mese per cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato un valore non consentito, il servizio restituirà un errore http 400 ed un  messaggio indicante la necessità del parametro con un valore compreso tra 1 e 12. </param>
        /// <param name="year">Anno per cui si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se per la coppia mese/anno inserita non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Nel caso di più valute il parametro sarà ripetuto.  Se il parametro  non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati. Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore</param>
        void DownloadMonthlyAverageRatesFile(FileFormat fileFormat, string outputFilePath, int month, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);

        /// <summary>
        /// Fornisce i cambi medi mensili per uno specifico mese/anno, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più  valute richieste, che siano valide e per le quali sia disponibile la quotazione. E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per il mese e le valute richieste, non esistano quotazioni, il servizio restituirà un elenco vuoto. 
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="month">Mese per cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato un valore non consentito, il servizio restituirà un errore http 400 ed un  messaggio indicante la necessità del parametro con un valore compreso tra 1 e 12. </param>
        /// <param name="year">Anno per cui si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se per la coppia mese/anno inserita non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Nel caso di più valute il parametro sarà ripetuto.  Se il parametro  non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati. Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore</param>
        /// <returns></returns>
        Task DownloadMonthlyAverageRatesFileAsync(FileFormat fileFormat, string outputFilePath, int month, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);
        #endregion

        #region annualAverageRates
        /// <summary>
        /// Fornisce i cambi medi annuali per uno specifico anno, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più  valute richieste, che siano valide e per le quali sia disponibile la quotazione per il mese selezionato.  E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per l’anno e le valute richieste, non esistano quotazioni, il servizio restituirà un elenco vuoto.
        /// </summary>
        /// <param name="year">Anno per cui si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se per l’anno inserito non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <param name="baseCurrencyIsoCode">Codice ISO(case insensitive) della valuta per cui si richiede  la quotazione.Nel caso di più valute il parametro sarà ripetuto.  Se il parametro non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati.Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore</param>
        /// <returns></returns>
        RatesResponse GetAnnualAverageRates(int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);

        /// <summary>
        /// Fornisce i cambi medi annuali per uno specifico anno, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più  valute richieste, che siano valide e per le quali sia disponibile la quotazione per il mese selezionato.  E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per l’anno e le valute richieste, non esistano quotazioni, il servizio restituirà un elenco vuoto.
        /// </summary>
        /// <param name="year">Anno per cui si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se per l’anno inserito non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <param name="baseCurrencyIsoCode">Codice ISO(case insensitive) della valuta per cui si richiede  la quotazione.Nel caso di più valute il parametro sarà ripetuto.  Se il parametro non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati.Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore</param>
        /// <returns></returns>
        Task<RatesResponse> GetAnnualAverageRatesAsync(int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);

        /// <summary>
        /// Fornisce i cambi medi annuali per uno specifico anno, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più  valute richieste, che siano valide e per le quali sia disponibile la quotazione per il mese selezionato.  E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per l’anno e le valute richieste, non esistano quotazioni, il servizio restituirà un elenco vuoto.
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="year">Anno per cui si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se per l’anno inserito non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <param name="baseCurrencyIsoCode">Codice ISO(case insensitive) della valuta per cui si richiede  la quotazione.Nel caso di più valute il parametro sarà ripetuto.  Se il parametro non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati.Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore</param>
        void DownloadAnnualAverageRatesFile(FileFormat fileFormat, string outputFilePath, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);

        /// <summary>
        /// Fornisce i cambi medi annuali per uno specifico anno, contro Euro o contro Dollaro USA o contro Lira Italiana, di una o più  valute richieste, che siano valide e per le quali sia disponibile la quotazione per il mese selezionato.  E' possibile non specificare le valute desiderate, in tal caso il servizio restituisce tutte le valute quotate. Qualora, per l’anno e le valute richieste, non esistano quotazioni, il servizio restituirà un elenco vuoto.
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="year">Anno per cui si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se per l’anno inserito non esistono dati il servizio restituirà un elenco vuoto.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <param name="baseCurrencyIsoCode">Codice ISO(case insensitive) della valuta per cui si richiede  la quotazione.Nel caso di più valute il parametro sarà ripetuto.  Se il parametro non viene passato, si intendono tutte le valute per cui è disponibile la quotazione nella data richiesta. Codici ISO inesistenti verranno scartati.Se tutti i codici ISO inseriti sono inesistenti, verrà restituita una lista vuota.Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore</param>
        /// <returns></returns>
        Task DownloadAnnualAverageRatesFileAsync(FileFormat fileFormat, string outputFilePath, int year, string currencyIsoCode, Language language = Language.It, string[] baseCurrencyIsoCode = null);
        #endregion


        #region dailyTimeSeries
        /// <summary>
        /// Fornisce i cambi giornalieri di una  valuta per un intervallo di date specificato. La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana. In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. La data di fine  non può essere antecedente quella di inizio, altrimenti sarà restituito un messaggio di errore.  
        /// E' consentita l'interrogazione su dati storici a partire dal 1918. 
        /// </summary>
        /// <param name="startDate">Data a partire da cui si richiedono le quotazioni. Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”- Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto.</param>
        /// <param name="endDate">Data fino a cui si richiedono le quotazioni. Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default</param>
        /// <returns></returns>
        RatesResponse GetDailyTimeSeries(DateTime startDate, DateTime endDate, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi giornalieri di una  valuta per un intervallo di date specificato. La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana. In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. La data di fine  non può essere antecedente quella di inizio, altrimenti sarà restituito un messaggio di errore.  
        /// E' consentita l'interrogazione su dati storici a partire dal 1918. 
        /// </summary>
        /// <param name="startDate">Data a partire da cui si richiedono le quotazioni. Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”- Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto.</param>
        /// <param name="endDate">Data fino a cui si richiedono le quotazioni. Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default</param>
        /// <returns></returns>
        Task<RatesResponse> GetDailyTimeSeriesAsync(DateTime startDate, DateTime endDate, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi giornalieri di una  valuta per un intervallo di date specificato. La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana. In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. La data di fine  non può essere antecedente quella di inizio, altrimenti sarà restituito un messaggio di errore.  
        /// E' consentita l'interrogazione su dati storici a partire dal 1918. 
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="startDate">Data a partire da cui si richiedono le quotazioni. Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”- Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto.</param>
        /// <param name="endDate">Data fino a cui si richiedono le quotazioni. Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default</param>
        void DownloadDailyTimeSeriesFile(FileFormat fileFormat, string outputFilePath, DateTime startDate, DateTime endDate, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi giornalieri di una  valuta per un intervallo di date specificato. La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana. In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. La data di fine  non può essere antecedente quella di inizio, altrimenti sarà restituito un messaggio di errore.  
        /// E' consentita l'interrogazione su dati storici a partire dal 1918. 
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="startDate">Data a partire da cui si richiedono le quotazioni. Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”- Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto.</param>
        /// <param name="endDate">Data fino a cui si richiedono le quotazioni. Viene interpretata relativamente al fuso orario dell’Europa Centrale  nel seguente formato: "yyyy-MM-dd”. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore.</param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default</param>
        /// <returns></returns>
        Task DownloadDailyTimeSeriesFileAsync(FileFormat fileFormat, string outputFilePath, DateTime startDate, DateTime endDate, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        #endregion


        #region monthlyTimeSeries
        /// <summary>
        /// Fornisce i cambi medi mensili di una valuta per un intervallo di mesi specificato.La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana.In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. Il mese di inizio non può essere successivo a quello finale, altrimenti sarà restituito un messaggio di errore.  
        /// </summary>
        /// <param name="startMonth">Mese da cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="startYear">Anno a partire dal quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endMonth">Mese fino a cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endYear">Anno fino al quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se la coppia mese/anno di fine è precedente alla coppia mese/anno di inizio, il servizio restituirà un messaggio di errore.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <returns></returns>
        RatesResponse GetMonthlyTimeSeries(int startMonth, int startYear, int endMonth, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi medi mensili di una valuta per un intervallo di mesi specificato.La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana.In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. Il mese di inizio non può essere successivo a quello finale, altrimenti sarà restituito un messaggio di errore.  
        /// </summary>
        /// <param name="startMonth">Mese da cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="startYear">Anno a partire dal quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endMonth">Mese fino a cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endYear">Anno fino al quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se la coppia mese/anno di fine è precedente alla coppia mese/anno di inizio, il servizio restituirà un messaggio di errore.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <returns></returns>
        Task<RatesResponse> GetMonthlyTimeSeriesAsync(int startMonth, int startYear, int endMonth, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi medi mensili di una valuta per un intervallo di mesi specificato.La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana.In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. Il mese di inizio non può essere successivo a quello finale, altrimenti sarà restituito un messaggio di errore.  
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="startMonth">Mese da cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="startYear">Anno a partire dal quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endMonth">Mese fino a cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endYear">Anno fino al quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se la coppia mese/anno di fine è precedente alla coppia mese/anno di inizio, il servizio restituirà un messaggio di errore.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        void DownloadMonthlyTimeSeriesFile(FileFormat fileFormat, string outputFilePath, int startMonth, int startYear, int endMonth, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi medi mensili di una valuta per un intervallo di mesi specificato.La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana.In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. Il mese di inizio non può essere successivo a quello finale, altrimenti sarà restituito un messaggio di errore.  
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="startMonth">Mese da cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="startYear">Anno a partire dal quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endMonth">Mese fino a cui si richiede la quotazione. Deve essere un intero compreso tra 1 e 12. Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endYear">Anno fino al quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se la coppia mese/anno di fine è precedente alla coppia mese/anno di inizio, il servizio restituirà un messaggio di errore.</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore.</param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default.</param>
        /// <returns></returns>
        Task DownloadMonthlyTimeSeriesFileAsync(FileFormat fileFormat, string outputFilePath, int startMonth, int startYear, int endMonth, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);
        #endregion


        #region annualTimeSeries
        /// <summary>
        /// Fornisce i cambi medi annuali di una valuta, per un intervallo di anni specificato. La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana. In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. L’anno di inizio non può essere successivo a quello finale, altrimenti sarà restituito un messaggio di errore.
        /// </summary>
        /// <param name="startYear">Anno a partire dal quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endYear">Anno fino al quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se l’anno di fine è precedente all’anno di inizio, il servizio restituirà un messaggio di errore</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore. </param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <returns></returns>
        RatesResponse GetAnnualTimeSeries(int startYear, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi medi annuali di una valuta, per un intervallo di anni specificato. La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana. In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. L’anno di inizio non può essere successivo a quello finale, altrimenti sarà restituito un messaggio di errore.
        /// </summary>
        /// <param name="startYear">Anno a partire dal quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endYear">Anno fino al quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se l’anno di fine è precedente all’anno di inizio, il servizio restituirà un messaggio di errore</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore. </param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <returns></returns>
        Task<RatesResponse> GetAnnualTimeSeriesAsync(int startYear, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi medi annuali di una valuta, per un intervallo di anni specificato. La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana. In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. L’anno di inizio non può essere successivo a quello finale, altrimenti sarà restituito un messaggio di errore.
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="startYear">Anno a partire dal quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endYear">Anno fino al quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se l’anno di fine è precedente all’anno di inizio, il servizio restituirà un messaggio di errore</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore. </param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        void DownloadAnnualTimeSeriesFile(FileFormat fileFormat, string outputFilePath, int startYear, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        /// <summary>
        /// Fornisce i cambi medi annuali di una valuta, per un intervallo di anni specificato. La valuta controvalore può essere Euro, Dollaro USA o Lira Italiana. In assenza di quotazioni per l'intervallo fornito, il servizio restituirà un elenco vuoto. L’anno di inizio non può essere successivo a quello finale, altrimenti sarà restituito un messaggio di errore.
        /// </summary>
        /// <param name="fileFormat">Formato del file in output</param>
        /// <param name="outputFilePath">Percorso del file in output</param>
        /// <param name="startYear">Anno a partire dal quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. </param>
        /// <param name="endYear">Anno fino al quale si richiede la quotazione. Deve essere un intero di 4 cifre nel formato YYYY.  Se il parametro non viene specificato, o è specificato in un formato errato, il servizio restituirà un messaggio  con il formato richiesto. Se l’anno di fine è precedente all’anno di inizio, il servizio restituirà un messaggio di errore</param>
        /// <param name="baseCurrencyIsoCode">Codice ISO (case insensitive) della valuta per cui si richiede  la quotazione. Se il codice ISO inserito è inesistente verrà restituita una lista vuota.  Se il parametro è specificato in un formato errato, il servizio restituirà un messaggio di errore. </param>
        /// <param name="currencyIsoCode">Codice ISO (case insensitive) della valuta "contro" cui si vuole la quotazione. Può valere “EUR”, “USD”, “ITL”. Se il parametro non è specificato, o è specificato un valore diverso da quelli validi, il servizio restituirà un messaggio di errore. </param>
        /// <param name="language">Lingua in cui si desidera ottenere i dati: può valere  “it” o “en” (case insensitive). Se il parametro non viene specificato, o viene valorizzato in modo errato, i risultati saranno forniti nella lingua di default. </param>
        /// <returns></returns>
        Task DownloadAnnualTimeSeriesFileAsync(FileFormat fileFormat, string outputFilePath, int startYear, int endYear, string baseCurrencyIsoCode, string currencyIsoCode, Language language = Language.It);

        #endregion
    }
}