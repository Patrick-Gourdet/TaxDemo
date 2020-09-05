using System;
using System.Collections.Generic;
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
        ITaxRates tax;
        private ITaxServiceDbContext _db;
        private IApiDbContext _dbApi;
        private IAuthContext _auth;
        private ILogger<TaxRatesController> _logger;
        /// <summary>
        /// Access To the TaxJar API 
        /// </summary>
        /// <param name="t"></param>
        public TaxRatesController(IAuthContext auth,ITaxRates t, ITaxServiceDbContext db,IApiDbContext dbApi, ILogger<TaxRatesController> tc)
        {
            tax = t;
            _db = db;
            _dbApi = dbApi;
            _logger = tc;
            _auth = auth;
        }
        /// <summary>
        /// This api takes the query string the api endpoint and the user
        /// hash obtained from the password to retrieve the API Key to make
        /// the desired request.
        /// [HttpGet("query/{endpoint}/{query}/{apiName}/{authorized}")]
        /// </summary>
        /// <param name="query"></param>
        /// <param name="apiName"></param>
        /// <param name="authorized"></param>
        /// <returns></returns>
        [HttpGet("query/{endpoint}/{query}/{apiName}/{authorized}")]
        public async Task<Rates> GetTaxInfo(string endpoint,string query,string apiName,string authorized= "")
        {
            try
            {
                var hash = Encoding.UTF8.GetBytes(authorized);
                var res = await tax.GetOrderTaxRate($"{endpoint}/{query}",apiName,hash);
                return res;
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Taxrate Call",e);
                throw new Exception("Error in GetTaxInfo",e);
            }

        }

    }
}
