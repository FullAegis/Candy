using System.Runtime;
using Candy.BLL.Mappers;    // Bll::User::ToDal()
using Candy.BLL.Interfaces; // IUserService
using Candy.DAL.Interfaces; // IUserRepository

namespace Candy.BLL.Services {
using Bll = Candy.BLL.Models;
using BCrypt = BCrypt.Net.BCrypt;

public class UserService(IUserRepository repository) : IUserService {
  private readonly IUserRepository _users = repository;


  public Bll::User Login(in string email, in string password) {
    try {
      var hash = _users.GetPassword(email);
      
      if (BCrypt.Verify(password, hash) is false) {
        throw new ArgumentException("Invalid password for this user.");
      }
      
      return _users.Get(email).ToBll();
    } catch (ArgumentNullException e) {
      throw new ArgumentException("Email address is incorrect.", nameof(email), e);
    }
  }

  public void Register(Bll::User user) {
    user.Password = BCrypt.HashPassword(user.Password);
    _users.Register(user.ToDal());
  }
};
}

