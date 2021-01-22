using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ShopDinePortland.Services;
using ShopDinePortland.Entities;

namespace ShopDinePortland.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody]User userParam)
    {
      var user = _userService.Authenticate(userParam.Username, userParam.Password);

      if (user == null)
      {
        return BadRequest(new { message = "Username or password is incorrect" });
      }
      return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var users =  _userService.GetAll();
      return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var user =  _userService.GetById(id);

      if (user == null)
      {
        return NotFound();
      }
      var currentUserId = int.Parse(User.Identity.Name);
      if (id != currentUserId && !User.IsInRole(Role.Admin))
      {
        return Forbid();
      }
      return Ok(user);
    }
  }
}