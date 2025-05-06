using System.ComponentModel.DataAnnotations;

namespace Candy.API.Models.DTO.Users {
public class UserRegisterFormDTO {
  public string LastName { get; set; }
  public string FirstName { get; set; }

  [Required] [EmailAddress]
  public required string Email { get; set; }
  
  private string _password;
  [Required]
  public required string Password {
    get => _password;
    set => _password = BCrypt.Net.BCrypt.HashPassword(value);
  }
};
}
