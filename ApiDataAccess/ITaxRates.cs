using System.Threading.Tasks;
using Auth.Model;

namespace Auth.ApiDataAccess
{
    /// <summary>
    /// Access to base tax-rates for any order this can be expanded to
    /// separate different tax brackets international or by region 
    /// </summary>
    public interface ITaxRates : ITax<Rates>
    {
        /// <summary>
        /// Interface for all tax rate endpoints
        /// </summary>
        /// <param name="query"></param>
        /// <param name="apiName"></param>
        /// <param name="userHash"></param>
        /// <returns></returns>
        Task<Rates> GetOrderTaxRate(string query,string apiName,byte[] userHash);
    }
}