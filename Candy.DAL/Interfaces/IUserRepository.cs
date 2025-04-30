using System.ComponentModel.DataAnnotations;

namespace Candy.DAL.Interfaces {
using Dal = Candy.DAL.Models;

public interface IUserRepository {
  void Register(in Dal::User user);
  Dal::User Get([EmailAddress] string email);
  string GetPassword([EmailAddress] string email);
};
}

