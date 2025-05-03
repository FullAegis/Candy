using System.ComponentModel.DataAnnotations;

namespace Candy.DAL.Interfaces {
using Dal = Candy.DAL.Models;

public interface IUserRepository {
  void Register(in Dal::User user);
  Dal::User Get(int id);
  Dal::User Get([EmailAddress] string email);
  void Update(int id, in Dal::User user);
  void Delete(in Dal::User user);
  void Delete(int id);
  string GetPassword([EmailAddress] string email);
  
};
}

