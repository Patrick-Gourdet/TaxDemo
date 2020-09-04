
using Auth.Model;
using Microsoft.EntityFrameworkCore;

namespace Auth.DataAccess
{
    /// <summary>
    /// This is the TaxJar interaction interface
    /// this will have the main functionality when interacting with the Tax apis
    /// </summary>
    public class DataContextTax : DbContext
    {
        public DataContextTax(DbContextOptions<DataContextTax> options) : base(options) {}
        public DbSet<TaxItemEvent> taxItem { get; set; }
        public DbSet<Rates> rates { get; set; }
        public DbSet<SummayRates> summaryRate { get; set; }
    }
}
