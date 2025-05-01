using System.ComponentModel.DataAnnotations;

namespace Candy.DAL.Models.Products {
  public record Category {
    [Required] public required int Id { get; init; }
    [Required] [StringLength(maximumLength: 100, MinimumLength = 1)]
    public required string Name { get; init; }
  };
}
  
