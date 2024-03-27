///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System.Threading.Tasks;
using TaxDemo.Model;

namespace TaxDemo.Business
{
    /// <summary>
    /// The business logic interface 
    /// </summary>
    public interface ICalculate
    {
        Task<TaxCalculationItemEvent>  CalculatedTax(RatesRate item,decimal amount);
    }
}
