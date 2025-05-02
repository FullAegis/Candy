using System.ComponentModel.DataAnnotations;

namespace Candy.BLL.Interfaces {
using Bll = Candy.BLL.Models;

public interface IUserService {
  Bll::User Login([EmailAddress] in string email, in string password);
  void Register(Bll::User user);
};
}
