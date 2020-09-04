using System.Threading.Tasks;
using Auth.Model;

namespace Auth.DataAccess
{
    /// <summary>
    /// Calculator class interface
    /// </summary>
    public interface ICalculateDbContext
    {
        Task<int> SaveChanges(TaxCalculationItemEvent item);
    }
}