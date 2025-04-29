using Microsoft.EntityFrameworkCore;

namespace Candy.API.Models.DTO {
using System.ComponentModel.DataAnnotations;

public class User {
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
};
}
  
