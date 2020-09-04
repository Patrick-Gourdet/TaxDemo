using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Model;

namespace Auth.DataAccess
{
    /// <summary>
    /// The tax item is the configuration of Ibase Context
    /// </summary>
    public interface ITaxServiceDbContext 
    {
        Task<string> GetTaxItem();
        Task<int> SaveChanges(Rates newRate);
        Task<IEnumerable<string>> GetTaxItems();
        Task Correction(string id);

    }
}