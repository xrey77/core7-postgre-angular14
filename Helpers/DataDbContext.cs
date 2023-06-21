using Microsoft.EntityFrameworkCore;
using core7_postgre_angular14.Entities;

namespace core7_postgre_angular14.Helpers
{

   public class DataDbContext : DbContext
    {

        // public DataDbContext(DbContextOptions<DataDbContext> options): base(options){
        // }        

        protected readonly IConfiguration Configuration;

        public DataDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

    }

}