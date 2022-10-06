using DAL;
using Microsoft.EntityFrameworkCore;
using RetailStoreAPI.Entities.Models;

namespace RetailStoreAPI.DAL
{
    public class RetailStoreDbContext : DbContext, IRetailStoreDbContext
    {
        public RetailStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
