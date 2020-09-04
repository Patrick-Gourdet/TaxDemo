
using System.Threading.Tasks;
using Auth.Model;

namespace Auth.ApiDataAccess
{
    /// <summary>
    /// Icalc rates access to the TaxRates over the Get Order Function
    /// /// </summary>
    public interface ICalcRates : ITax<Rates>
    {
        Task<Rates> GetOrderTaxRate(string query, string apiName, byte[] userHash);
    }
}
