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
  public class ShopsController : ControllerBase
  {
    private ShopDinePortlandContext _db;

    public ShopsController(ShopDinePortlandContext db)
    {
      _db = db;
    }
    
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Shop>> Get(string name, string type, string neighborhood)
    {
      var query = _db.Shops.AsQueryable();
      if(name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if(type != null)
      {
        query = query.Where(entry => entry.Type == type);
      }
      if(neighborhood != null)
      {
        query = query.Where(entry => entry.Neighborhood == neighborhood);
      }
      return query.ToList();
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Shop> Get(int id)
    {
      return _db.Shops.FirstOrDefault(entry => entry.ShopId == id);
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPost]
    public void Post([FromBody] Shop shop)
    {
      _db.Shops.Add(shop);
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Shop shop)
    {
      shop.ShopId = id;
      _db.Entry(shop).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var shopToDelete = _db.Shops.FirstOrDefault(entry => entry.ShopId == id);
      _db.Shops.Remove(shopToDelete);
      _db.SaveChanges();
    }
  }
}