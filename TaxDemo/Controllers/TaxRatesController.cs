///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.IO;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using TaxDemo.ApiDataAccess;
using TaxDemo.DataAccess.InterfaceContexts;
using TaxDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxDemo.Controllers
{
    /// <summary>
    ///   Auth
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
        /// Hash obtained from the password to retrieve the API Key to make
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
        /// <summary>
        /// Get Tax info for region of interest
        /// </summary>
        /// <param name="query"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Retuen all rates
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("all-calculations/{user}/{password}")]
        public async Task<IActionResult> Get(string user, string password)
        {
            try
            {
                var hash = Encoding.UTF8.GetBytes(_auth.GetUserHash(user,password).Result);
                var res = await _db.GetQueriedTaxByFrequency();
                return (IActionResult) res;
            }
            catch (Exception e)
            {
                throw new Exception("Error in Calculation end point endpoint", e);
            }

        }
        /// <summary>
        /// Retuen all rates above x from the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("all-tax-Above/{user}/{password}/{amount}")]
        public async Task<IActionResult> GetQueriedTaxByFrequency(string user, string password,decimal input )
        {
            try
            {
                var hash = Encoding.UTF8.GetBytes(_auth.GetUserHash(user,password).Result);
                if(hash.Length == 0) throw new AuthenticationException("Not Authorized");
                var res = await _db.GetQueriedTaxByFrequency();
                return Ok(res);
            }
            catch (Exception e)
            {
                throw new Exception("Error in Calculation end point endpoint", e);
            }

        }

    }
}
