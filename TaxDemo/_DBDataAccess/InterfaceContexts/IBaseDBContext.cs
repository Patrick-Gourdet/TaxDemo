///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using System.Threading.Tasks;
using TaxDemo.Model;

namespace TaxDemo.DataAccess.InterfaceContexts
{
    /// <summary>
    /// This is the base interface for the DB access functions
    /// </summary>
    public interface IBaseDbContext
    {
        /// <summary>
        /// This takes in the Model and saves to the Database in question        /// </summary>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<int> SaveChanges(TaxCalculationItemEvent item);
    }
}
