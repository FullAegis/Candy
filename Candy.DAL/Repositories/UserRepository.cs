using Candy.DAL.Models;

namespace Candy.DAL.Repositories {
using Candy.DAL.Interfaces;
  
public class UserRepository(CandyDbContext context) : IUserRepository {
  private readonly CandyDbContext _context = context;
  
  public void Register(in User user) =>  _context.Users.Add(user);

  public User Get(string email) {
    var user = _context.Users.FirstOrDefault(u => u.Email == email);
    ArgumentNullException.ThrowIfNull(user);
    return user;
  }

  public string GetPassword(string email) {
    var user =  _context.Users.FirstOrDefault(u => u.Email == email);
    ArgumentNullException.ThrowIfNull(user);
    return user.Password;
  }
};
}

