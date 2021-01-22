using Microsoft.EntityFrameworkCore;

namespace ShopDinePortland.Models
{
  public class ShopDinePortlandContext : DbContext
  {
    public ShopDinePortlandContext(DbContextOptions<ShopDinePortlandContext> options)
      : base(options)
      {
      }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Shop> Shops { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Restaurant>()
        .HasData(
          new Restaurant { RestaurantId = 1, Name = "Tusk", Cuisine = "Mediterranean", Service="Casual Dining", Neighborhood="East Burnside"},
          new Restaurant { RestaurantId = 2, Name = "DeNicola's", Cuisine = "Italian", Service="Casual Dining", Neighborhood="Southeast"},
          new Restaurant { RestaurantId = 3, Name = "PDX Sliders", Cuisine = "American", Service="Casual Dining", Neighborhood="Sellwood"},
          new Restaurant { RestaurantId = 4, Name = "Guero", Cuisine = "Mexican", Service="Casual Dining", Neighborhood="Laurelhurst"},
          new Restaurant { RestaurantId = 5, Name = "Stretch The Noodle", Cuisine = "Chinese", Service="To-go", Neighborhood="Downtown"}
        );

      builder.Entity<Shop>()
        .HasData(
          new Shop { ShopId = 1, Name = "Frances May", Type = "Clothing", Neighborhood="West End"},
          new Shop { ShopId = 2, Name = "Machus", Type = "Clothing", Neighborhood="East Burnside"},
          new Shop { ShopId = 3, Name = "Hay", Type = "Homegoods", Neighborhood="Pearl"},
          new Shop { ShopId = 4, Name = "Stars Mall", Type = "Antiques", Neighborhood="Sellwood"},
          new Shop { ShopId = 5, Name = "Beam and Anchor", Type = "Homegoods", Neighborhood="Northeast"}
        );
    }
  }
}