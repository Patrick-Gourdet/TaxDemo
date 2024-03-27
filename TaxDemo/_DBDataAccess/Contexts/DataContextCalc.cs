//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author: Patrick Gourdet Reinhard
/// Company: Iron Finacials LLC
/// Date: 09/03/2020
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using TaxDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace TaxDemo.DataAccess.Contexts
{
    /// <summary>
    /// Calculator Interface implements Save To Sqlite DB
    /// </summary>
    public class DataContextCalc : DbContext
    {
        public DataContextCalc(DbContextOptions<DataContextCalc> options) : base(options) {}
        public DbSet<TaxCalculationItemEvent> taxCalculationUsingZip { get; set; }
        public DbSet<CalculationModel> calculationEndPoint { get; set; }

    }
}
