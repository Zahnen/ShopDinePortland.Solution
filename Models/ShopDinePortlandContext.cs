using Microsoft.EntityFrameworkCore;

namespace ShopDinePortland.Models
{
    public class ShopDinePortlandContext : DbContext
    {
        public ShopDinePortlandContext(DbContextOptions<ShopDinePortlandContext> options)
            : base(options)
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}