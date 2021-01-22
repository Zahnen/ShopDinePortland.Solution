using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShopDinePortland.Models;

namespace ShopDinePortland.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RestaurantsController : ControllerBase
  {
    private ShopDinePortlandContext _db;

    public RestaurantsController(ShopDinePortlandContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Restaurant>> Get()
    {
      return _db.Restaurants.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Restaurant> Get(int id)
    {
      return _db.Restaurants.FirstOrDefault(entry => entry.RestaurantId == id);
    }

    [HttpPost]
    public void Post([FromBody] Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
    }
  }
}