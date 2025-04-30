using System.ComponentModel.DataAnnotations;

namespace Candy.API.Models.DTO.Products;

public record struct Category(in string name) {
  [Required] public required int Id { get; init; }
  [Required] public required string Name { get; init; } = name;
}
