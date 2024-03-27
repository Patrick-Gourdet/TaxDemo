///////////////////////////////////////////////////////////////////////////////////////////////
// Author: Patrick Gourdet Reinhard
// License: Iron Financials LLC All Rights Reserved
// Email: patrick.g.reinhard@ironfinancials.com
// Date: 09/11/2020
///////////////////////////////////////////////////////////////////////////////////////////////
using TaxDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace TaxDemo.DataAccess.Contexts
{
    /// <summary>
    /// This is the TaxJar interaction interface
    /// this will have the main functionality when interacting with the Tax apis
    /// </summary>
    public class DataContextTax : DbContext
    {
        public DataContextTax(DbContextOptions<DataContextTax> options) : base(options) {}
        public DbSet<TaxItemEvent> taxItem { get; set; }
        public DbSet<RatesRate> rates { get; set; }
    }
}
