using System.ComponentModel.DataAnnotations;

namespace Candy.API.Models.DTO.Users {
public class UserRegisterFormDTO {
  [Required] public string LastName { get; set; }
  [Required] public string FirstName { get; set; }

  [Required] [EmailAddress]
  public string Email { get; set; }

  [Required] public string Password { get; set; }
};
}
