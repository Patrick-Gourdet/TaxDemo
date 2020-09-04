
using System.Threading.Tasks;
using Auth.Model;

namespace Auth.Business
{
    /// <summary>
    /// The business logic interface 
    /// </summary>
    public interface ICalculate
    {
        Task<TaxCalculationItemEvent>  CalculatedTax(Rates item,decimal amount);
    }
}
