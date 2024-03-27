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
    /// Calculator class interface
    /// </summary>
    public interface ICalculateDbContext
    {
        Task<int> SaveChanges(TaxCalculationItemEvent item);
        Task<List<TaxCalculationItemEvent>> GetCalculations();
    }
}