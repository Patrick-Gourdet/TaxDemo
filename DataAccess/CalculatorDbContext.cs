//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author: Patrick Gourdet 
/// Company: Iron Finacials LLC
/// Date: 09/03/2020
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Threading.Tasks;
using Auth.Model;

namespace Auth.DataAccess
{
    /// <summary>
    /// Calculation Db access
    /// the data from tax rates can be accessed either DB or API 
    /// </summary>
    public class CalculatorDbContext :  ICalculateDbContext
    {

        private readonly DataContextCalc _context;
        /// <summary>
        /// Injecting the shared DB context into the controller
        /// TODO Abstract db from controller in separate class
        /// </summary>
        /// <param name="context"></param>
        public CalculatorDbContext(DataContextCalc context)
        {
            _context = context;
        }

        public async Task<int> SaveChanges(TaxCalculationItemEvent item)
        {
            _context.taxCalcItem.Add(item);
            return await _context.SaveChangesAsync();
            
        }
    }
}