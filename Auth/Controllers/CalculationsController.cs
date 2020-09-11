///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Auth.ApiDataAccess;
using Auth.Business;
using Auth.DataAccess.InterfaceContexts;
using Auth.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.Controllers
{
    /// <summary>
    /// gives access to the calculated DB
    /// and the function to calculate the rates for an order
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private ICalculatorApiAccessor _calcApi;
        private ICalculateDbContext _db;
        private ILogger<CalculationsController> _logger;
        private IAuthContext _auth;
        private ICalculate _calc;
        /// <summary>
        /// Access To the TaxJar API 
        /// </summary>
        /// <param name="t"></param>
        public CalculationsController(IAuthContext auth,
            ICalculatorApiAccessor calcApi, 
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

        /// <summary>
        /// Tax Jar Endpoint For Calculator
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="zip"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("taxjar/{amount}/{zip}/{user}/{password}")]
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

        /// <summary>
        /// Access to assign API keys to Employees on a no Trust Basis
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="query"></param>
        /// <param name="apiname"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("rates/{amount}/{query}/{apiname}/{user}/{password}")]
        public async Task<TaxCalculationItemEvent> Get(string amount, string query,string apiname,string user, string password)
        {
            try
            {
                var hash = Encoding.UTF8.GetBytes(_auth.GetUserHash(user,password).Result);
                var getRates = await _calcApi.GetOrderTaxRate(query,apiname,hash);
                var resultCalculations = await _calc.CalculatedTax(getRates, Convert.ToDecimal(amount));
                await _db.SaveChanges(resultCalculations);
                return resultCalculations;
            }
            catch (Exception e)
            {
                throw new Exception("Error in rates endpoint", e);
            }

        }
        /// <summary>
        /// Endpoint to obtain all prior calculated orders
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("all-calculations/{user}/{password}")]
        public async Task<List<TaxCalculationItemEvent>> Get(string user, string password)
        {
            try
            {
                var hash = Encoding.UTF8.GetBytes(_auth.GetUserHash(user,password).Result);
                var res = await _db.GetCalculations();
                return res;
            }
            catch (Exception e)
            {
                throw new Exception("Error in Calculation end point endpoint", e);
            }

        }
    }
}
