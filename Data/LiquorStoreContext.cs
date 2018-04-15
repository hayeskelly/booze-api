using Microsoft.EntityFrameworkCore;

namespace BuckIBooze.API.Models
{
    public class LiquorStoreContext : DbContext
    {
        public LiquorStoreContext(DbContextOptions<LiquorStoreContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

        public DbSet<Product> Products {get; set;}    
        public DbSet<Order> Orders {get; set;}
    }
}

