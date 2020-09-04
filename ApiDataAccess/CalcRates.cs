﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Auth.DataAccess;
using Auth.Model;
using Newtonsoft.Json;
using TaxJar.Microservice.DataAccess.ApiHelper;

namespace Auth.ApiDataAccess
{
    /// <summary>
    /// Main calculation method for all tax calculations 
    /// </summary>
    public class CalcRates : ICalcRates
    {
        private const string _base = "https://api.taxjar.com/v2/rates";
        public readonly DataContextApi _context;

        /// <summary>
        /// Concrete implemnetation of the interface which also uses the Api access for authorization
        /// </summary>
        /// <param name="contex"></param>
        public CalcRates(DataContextApi contex)
        {
            _context = contex;
        }

        //https://api.taxjar.com/v2/rates/90404-3370
        /// <inheritdoc />
        public async Task<Rates> GetOrderTaxRate(string query, string apiName, byte[] userHash)
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
                var taxItem = JsonConvert.DeserializeObject<Rates>(res);


                return taxItem;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task GetTaxInfo(Rates action)
        {
            throw new NotImplementedException();
        }
    }
}