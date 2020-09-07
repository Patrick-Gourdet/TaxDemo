using System.Threading.Tasks;
using Auth.Model;

namespace Auth.DataAccess.InterfaceContexts
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
