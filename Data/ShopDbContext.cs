using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;

namespace ShopAPI.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
