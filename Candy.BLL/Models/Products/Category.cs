using System.ComponentModel.DataAnnotations;

namespace Candy.BLL.Models.Products;

public record Category(in string name) {
  [Required] public required int Id { get; init; }
  [Required] public required string Name { get; init; } = name;
}
