using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candy.API.Models.DTO.Users {
public class UserLoginFormDTO {
  [Required] [EmailAddress] public string Email { get; set; }
  [Required] public string Password { get; set; }
}; 
}

