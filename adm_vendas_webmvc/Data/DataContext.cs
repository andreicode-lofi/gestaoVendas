using adm_vendas_webmvc.Models;
using Microsoft.EntityFrameworkCore;


namespace adm_vendas_webmvc.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<DepartmentModel> Department { get; set; }
        public DbSet<SalesRecordModel> SalesRecord { get; set; }
        public DbSet<SellerModel> Seller { get; set; }
    }
}
