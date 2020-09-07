using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Model;

namespace Auth.DataAccess.InterfaceContexts
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