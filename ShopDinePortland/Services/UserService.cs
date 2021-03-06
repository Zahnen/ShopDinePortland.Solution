using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopDinePortland.Entities;
using ShopDinePortland.Helpers;

namespace ShopDinePortland.Services
{
  public interface IUserService
  {
    User Authenticate(string username, string password);
    IEnumerable<User> GetAll();
    User GetById(int id);
  }

  public class UserService : IUserService
  {
    private List<User> _users = new List<User>
    { 
      new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", Password = "admin", Role = Role.Admin },
      new User { Id = 2, FirstName = "User", LastName = "User", Username = "user", Password = "user", Role = Role.User } 
    };

    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings)
    {
      _appSettings = appSettings.Value;
    }

    public User Authenticate(string username, string password)
    {
      var user = _users.SingleOrDefault(u => u.Username == username && u.Password == password);
      if (user == null)
      {
        return null;
      }

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.Id.ToString()),
          new Claim(ClaimTypes.Role, user.Role)  
        }),
        Expires = DateTime.UtcNow.AddDays(5),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      user.Token = tokenHandler.WriteToken(token);
      user.Password = null;
      return user;
    }

    public IEnumerable<User> GetAll()
    {
      return _users.Select(u => {
        u.Password = null;
        return u;
      });
    }

    public User GetById(int id)
    {
      var user = _users.FirstOrDefault(x => x.Id == id);
      if (user != null)
      {
        return null;
      }
      return user;
    }
  }
}