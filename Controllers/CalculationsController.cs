using System;

using System.Text;
using System.Threading.Tasks;
using Auth.ApiDataAccess;
using Auth.Business;
using Auth.DataAccess;
using Auth.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.Controllers
{
    /// <summary>
    /// Calculator controller
    /// gives access to the calculated DB
    /// and the function to calculate the rates for an order
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private ICalcRates _calcApi;
        private ICalculateDbContext _db;
        private ILogger<CalculationsController> _logger;
        private IAuthContext _auth;
        private ICalculate _calc;
        /// <summary>
        /// Access To the TaxJar API 
        /// </summary>
        /// <param name="t"></param>
        public CalculationsController(IAuthContext auth,
            ICalcRates calcApi, 
            ICalculateDbContext db,
            ILogger<CalculationsController> tc,
            ICalculate calc)
        {
            _calcApi = calcApi;
            _db = db;
            _logger = tc;
            _auth = auth;
            _calc = calc;
        }

        // GET api/<CalculationsController>/5
        [HttpGet("taxjar/{amount}/{zip}/(user)/{password}")]
        public async Task<TaxCalculationItemEvent> Get(decimal amount, string zip,string user, string password)
        {
            try
            {
                var hash = Encoding.UTF8.GetBytes(
                    _auth.GetUserHash(user,password).Result
                    );
                var getRates = await _calcApi.GetOrderTaxRate($"?zip={zip}","taxjar",hash);
                var resultCalculations = await _calc.CalculatedTax(getRates, Convert.ToDecimal(amount));
                await _db.SaveChanges(resultCalculations);
                return resultCalculations;
            }
            catch(Exception e)
            {
                throw new Exception("Error in Get TaxJar APi",e);
            }

        }

        // GET api/<CalculationsController>/5
        [HttpGet("rates/{amount}/{zip}/{endpoint}/(user)/{password}")]
        public async Task<TaxCalculationItemEvent> Get(string amount, string zip,string endpoint,string user, string password)
        {
            try
            {
                var hash = Encoding.UTF8.GetBytes(_auth.GetUserHash(user,password).Result);
                var getRates = await _calcApi.GetOrderTaxRate($"?zip={zip}",endpoint,hash);
                var resultCalculations = await _calc.CalculatedTax(getRates, Convert.ToDecimal(amount));
                await _db.SaveChanges(resultCalculations);
                return resultCalculations;
            }
            catch (Exception e)
            {
                throw new Exception("Error in rates endpoint", e);
            }

        }
    }
}
