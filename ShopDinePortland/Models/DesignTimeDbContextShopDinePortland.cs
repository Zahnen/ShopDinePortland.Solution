using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ShopDinePortland.Models
{
  public class ShopDinePortlandContextFactory : IDesignTimeDbContextFactory<ShopDinePortlandContext>
  {

    ShopDinePortlandContext IDesignTimeDbContextFactory<ShopDinePortlandContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<ShopDinePortlandContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new ShopDinePortlandContext(builder.Options);
    }
  }
}