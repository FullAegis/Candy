using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Candy.API.Models.DTO {
  public class User {
    public int    Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
  };
}
