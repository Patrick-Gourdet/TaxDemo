using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Auth.DataAccess;
using Auth.Model;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using TaxJar.Microservice.DataAccess;
using TaxJar.Microservice.DataAccess.ApiHelper;

namespace Auth.ApiDataAccess
{
    /// <summary>
    ///  Tax Rate retrieval
    /// Access the APIDb directly
    /// TODO In Future the API DB access should call class an not access the DB directly 
    /// </summary>
    public class TaxRates : ITaxRates
    {
        /// Base url 
        private const string _base = "https://api.taxjar.com/v2/";

        private readonly DataContextApi _context;
        private readonly DataContextTax _contextTax;


        /// <summary>
        /// Database context injection according to design
        /// </summary>
        /// <param name="dbContext"></param>
        public TaxRates(DataContextApi dbContext,DataContextTax dataContextTax)
        {
            _context = dbContext;
            _contextTax = dataContextTax;
        }

        /// <summary>
        /// Get Tax Rates for a query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="apiName"></param>
        /// <param name="userHash"></param>
        /// <returns></returns>
        public async Task<RatesRate> GetOrderTaxRate(string query, string apiName, byte[] userHash)
        {
            try
            {
                IApiDbContext apiAcess = new ApiDbContext(_context);
                ITaxServiceDbContext taxAcess = new TaxServiceDbContext(_contextTax);
                var apiKey = await apiAcess.GetApiKey(apiName, userHash);
                var single = HttpClientSingleton.TaxClient;
                // call to HttpSingleton Class to set requiered headers 
                HttpClientSingleton.SetHeaders("Authorization", $"Bearer {apiKey}");
                HttpClientSingleton.SetHeadersAccept("application/json");

                // Create Query String for API call
                var queryString = string.Concat(_base, query);

                var receiveStream = await HttpClientSingleton.TaxClient.GetStreamAsync(queryString);
                using var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var res = await readStream.ReadToEndAsync();
                var taxItem = JsonConvert.DeserializeObject<RatesRate>(res);
                await taxAcess.SaveChanges(taxItem);
                HttpClientSingleton.TaxClient.Dispose();
                return taxItem;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        /// <summary>
        /// TODO resolve any requests to the Database on the stored rates regions types
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task GetTaxInfo(RatesRate action)
        {
            throw new NotImplementedException();
        }

    }
}