using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auth.Model;
using TaxJar.Microservice.DataAccess;

namespace Auth.DataAccess
{
    /// <summary>
    /// Main context hub
    /// </summary>
    public class TaxServiceDbContext : ITaxServiceDbContext
    {
        public readonly DataContextTax _context;
        public TaxServiceDbContext(DataContextTax context)
        {
            _context = context;
        }

        /// <summary>
        /// Save changes to the Tax Item Db
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChanges(RatesRate newRateRate)
        {
            var rate = new RatesRate();
            rate = newRateRate as RatesRate;
            rate.id = Guid.NewGuid();
            
            await _context.rates.AddAsync(rate,new CancellationToken());
            return await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Not yet implemented but will retrieve one of the past queries to the
        /// Tax api
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<string> GetTaxItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not yet implemented. Will get all the elements of historical api calls
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<string>> GetTaxItems()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This allows for correction of faulty data TODO needs to be implemented
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task Correction(string id)
        {
            throw new NotImplementedException();
        }
    }
}