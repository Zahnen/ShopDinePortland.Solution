using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ShopDinePortland.Models;
using ShopDinePortland.Entities;
using ShopDinePortland.Services;


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

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Restaurant>> Get(string name, string cuisine, string service, string neighborhood)
    {
      var query = _db.Restaurants.AsQueryable();
      if(name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if(cuisine != null)
      {
        query = query.Where(entry => entry.Cuisine == cuisine);
      }
      if(service != null)
      {
        query = query.Where(entry => entry.Service == service);
      }
      if(neighborhood != null)
      {
        query = query.Where(entry => entry.Neighborhood == neighborhood);
      }
      return query.ToList();
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Restaurant> Get(int id)
    {
      return _db.Restaurants.FirstOrDefault(entry => entry.RestaurantId == id);
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPost]
    public void Post([FromBody] Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Restaurant restaurant)
    {
      restaurant.RestaurantId = id;
      _db.Entry(restaurant).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var restaurantToDelete = _db.Restaurants.FirstOrDefault(entry => entry.RestaurantId == id);
      _db.Restaurants.Remove(restaurantToDelete);
      _db.SaveChanges();
    }
  }
}