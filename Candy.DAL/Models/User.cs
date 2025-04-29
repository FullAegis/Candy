using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Candy.DAL.Models {
  
public class User {
  [Required]
  public int Id { get; set; }
  [MaxLength(128)]
  public string LastName { get; set; }
  [MaxLength(128)]
  public string FirstName { get; set; }
  
  [Required]
  [EmailAddress]
  public string Email { get; set; }
};
}
