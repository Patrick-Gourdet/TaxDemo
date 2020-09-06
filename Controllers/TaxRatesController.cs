using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Auth.ApiDataAccess;
using Auth.DataAccess;
using Auth.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxJar.Microservice.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.Controllers
{
    /// <summary>
    ///   [Route("api/[controller]")]
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaxRatesController : ControllerBase
    {
        private const string apiName = "taxjar";
        ITaxRates _tax;
        private ITaxServiceDbContext _db;
        private IAuthContext _auth;

        private ILogger<TaxRatesController> _logger;
        /// <summary>
        /// Access To the TaxJar API 
        /// </summary>
        /// <param name="t"></param>
        public TaxRatesController(
            IAuthContext auth,
            ITaxRates t, 
            ITaxServiceDbContext db, 
            ILogger<TaxRatesController> tc
            )
        {
            _tax = t;
            _auth = auth;
            _db = db;
            _logger = tc;
        }
        /// <summary>
        /// This api takes the query string the api endpoint and the user
        /// hash obtained from the password to retrieve the API Key to make
        /// the desired request.
        /// [HttpGet("query/{endpoint}/{query}/{apiName}/{authorized}")]
        /// </summary>
        /// <param name="query"></param>
        /// <param name="zip"></param>
        /// <returns></returns>
        [HttpGet("query/{zip}/{state}/{user}/{password}")]
        public async Task<RatesRate> GetTaxInfo(string zip,string state,string user,string password= "")
        {
            try
            {
                
                var hash = Encoding.UTF8.GetBytes(
                    _auth.GetUserHash(user,password).Result
                );
                var getRates = await _tax.GetOrderTaxRate($"rates?zip={zip}&state={state}",apiName,hash);
                await _db.SaveChanges(getRates);
                return getRates;
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Tax rate Call",e);
                throw new Exception("Error in GetTaxInfo",e);
            }

        }
        [HttpGet("query/{query}/{user}/{password}")]
        public async Task<RatesRate> GetTaxInfoQuery(string query,string user,string password= "")
        {
            try
            {
                var hash = Encoding.UTF8.GetBytes(
                    _auth.GetUserHash(user,password).Result
                );
                if (!query.Contains('-') || !query.Contains('?'))
                {
                    int.TryParse(query, out int result);
                    if (result == 0)
                        throw new InvalidDataException("Malformed query string");
                }
                var getRates = await _tax.GetOrderTaxRate($"rates/{query}",apiName,hash);
                await _db.SaveChanges(getRates);
                return getRates;
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Tax rate Call",e);
                throw new Exception("Error in GetTaxInfo",e);
            }

        }

    }
}
