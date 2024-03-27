///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxDemo.Model;

namespace TaxDemo.DataAccess.InterfaceContexts
{
    /// <summary>
    /// The tax item is the configuration of Ibase Context
    /// </summary>
    public interface ITaxServiceDbContext 
    {
        Task<string> GetTaxItem();
        Task<int> SaveChanges(RatesRate newRateRate);
        Task<List<RatesRate>> GetTaxItems();
        Task Correction(string id);
        Task<List<RatesRate>> GetQueriedTaxByFrequency();

    }
}