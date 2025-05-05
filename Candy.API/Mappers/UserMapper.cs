namespace Candy.Mappers {
using Bll = Candy.BLL.Models;
using Api = Candy.API.Models.DTO;
using BCrypt = BCrypt.Net.BCrypt;

public static class UserMapper {
  public static Api::User ToApi(this Bll::User user) => new Api::User
  { Id = user.Id
  , FirstName = user.FirstName
  , LastName = user.LastName
  , Email =  user.Email
  };
  
  public static Bll::User ToBll(this Api::User user, in string password) => new Bll::User
  { Id = user.Id
  , FirstName = user.FirstName
  , LastName = user.LastName
  , Email = user.Email
  , Password = BCrypt.HashPassword(password)
  };
  
  public static Bll::User ToBll(this UserRegisterFormDTO form) => new Bll::User
  { Id = form.Id
  , FirstName = form.FirstName
  , LastName = form.LastName
  , Email = form.Email
  , Password = BCrypt.HashPassword(form.Password)
  };
  
};
}
