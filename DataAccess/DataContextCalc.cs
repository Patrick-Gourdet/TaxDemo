//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author: Patrick Gourdet 
/// Company: Iron Finacials LLC
/// Date: 09/03/2020
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using Auth.Model;
using Microsoft.EntityFrameworkCore;

namespace Auth.DataAccess
{
    /// <summary>
    /// Calculator Interface implements Save To Sqlite DB
    /// </summary>
    public class DataContextCalc : DbContext
    {
        public DataContextCalc(DbContextOptions<DataContextCalc> options) : base(options) {}
        public DbSet<TaxCalculationItemEvent> taxCalcItem { get; set; }
    }
}
