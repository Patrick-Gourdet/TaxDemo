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
    /// Api Context for access and storage of the
    /// configured api keys for authenticated users
    /// </summary>
    public interface IApiDbContext
    {
        

        /// <summary>
        /// Api key access function
        /// </summary>
        /// <param name="apiName"></param>
        /// <param name="compareHash"></param>
        /// <returns></returns>
        Task<string> GetApiKey(string apiName, byte[] compareHash);
        /// <summary>
        /// Save changes or new api keys the Item takes
        /// the apikeyitem model
        /// </summary>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<int> SaveChanges(ApiDbItem item);
    }
}
