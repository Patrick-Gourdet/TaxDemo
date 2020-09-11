///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Auth.DataAccess;
using Auth.DataAccess.Contexts;
using Auth.Model;
using Newtonsoft.Json;
using TaxJar.Microservice.DataAccess.ApiHelper;

namespace Auth.ApiDataAccess
{
    /// <summary>
    /// Main calculation method for all tax calculations 
    /// </summary>
    public class CalculatorTaxTatesAPIAccessor : ICalculatorApiAccessor
    {
        private const string _base = "https://api.taxjar.com/v2/rates";
        public readonly DataContextApi _context;

        /// <summary>
        /// Concrete implemnetation of the interface which also uses the Api access for authorization
        /// </summary>
        /// <param name="contex"></param>
        public CalculatorTaxTatesAPIAccessor(DataContextApi contex)
        {
            _context = contex;
        }

        //https://api.taxjar.com/v2/rates/90404-3370
        /// <inheritdoc />
        public async Task<RatesRate> GetOrderTaxRate(string query, string apiName, byte[] userHash)
        {
            try
            {
                if (!query.Contains('?') && !query.Contains('-'))
                    throw new InvalidDataException("Malformed query string");

                var api = new ApiDbContext(_context);

                var apiKey = await api.GetApiKey(apiName, userHash);

                // call to HttpSingleton Class to set requiered headers 
                HttpClientSingleton.SetHeaders("Authorization", $"Bearer {apiKey}");
                HttpClientSingleton.SetHeadersAccept("application/json");

                // Create Query String for API call
                var queryString = string.Concat(_base, query);

                var receiveStream = await HttpClientSingleton.TaxClient.GetStreamAsync(queryString);
               

                using var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var res = await readStream.ReadToEndAsync();
                var taxItem = JsonConvert.DeserializeObject<RatesRate>(res);


                return taxItem;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// TODO Dynamic tax info retrieval
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