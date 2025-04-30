using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Candy.DAL.Models {
  
public class User {
  public required int Id { get; set; }
  
  [MaxLength(128)]
  public string LastName { get; set; }
  [MaxLength(128)]
  public string FirstName { get; set; }
  
  [Required]
  [EmailAddress]
  public required string Email { get; set; }
  
  [Required]
  [PasswordPropertyText]
  public required string Password { get; set; }
};
}
