///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System.Threading.Tasks;
using Auth.Model;

namespace Auth.ApiDataAccess
{
    /// <summary>
    /// Icalc rates access to the TaxRates over the Get Order Function
    /// /// </summary>
    public interface ICalculatorApiAccessor : ITax<RatesRate>
    {
        Task<RatesRate> GetOrderTaxRate(string query, string apiName, byte[] userHash);
    }
}
