//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Author: Patrick Gourdet Reinhard
/// Company: Iron Finacials LLC
/// Date: 08/28/2020
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using TaxDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace TaxDemo.DataAccess.Contexts
{
    public class DataContextApi : DbContext
    {
        public DataContextApi(DbContextOptions<DataContextApi> options) : base(options) {}
   
        public DbSet<ApiDbItem> apiDBItem { get; set; }

    }
}

       
