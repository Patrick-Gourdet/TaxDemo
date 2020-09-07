using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Model;

namespace Auth.DataAccess.InterfaceContexts
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