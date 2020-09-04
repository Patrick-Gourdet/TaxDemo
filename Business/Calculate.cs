using System;
using System.Threading.Tasks;
using Auth.Model;

namespace Auth.Business
{
    /// <summary>
    /// Calculate the tax for a given api call to taxjar using the combined tax rate
    /// </summary>
    public class Calculate : ICalculate
    {
        public async Task<TaxCalculationItemEvent> CalculatedTax(Rates item, decimal amount)
        {
          
            var calculated = Convert.ToDecimal(item.rate.combined_rate) * amount;
            var calculateAsync = TaskEx.Run( () =>
            {
                return new TaxCalculationItemEvent()
                {
                    Amount = amount,
                    CalcId = new Guid(),
                    CalculatedAmount = calculated,
                    CreatedDate = DateTime.Now,
                    Percent = amount
                };

            });
           
            return  await calculateAsync;
        }
    }
}
