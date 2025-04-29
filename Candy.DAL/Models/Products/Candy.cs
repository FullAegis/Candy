using System.ComponentModel.DataAnnotations;

namespace Candy.DAL.Models.Products {
public class Candy {
  public int Id { get; set; }
  [Required] [MaxLength(128)]
  
  public required string Name { get; set; }
  [Required] public required Brand Brand { get; set; }
  
  [Required] [Range(1e-3, 1e+9)] // [0.001, 1_000_000_000]
  public required decimal PriceBeforeTax { get; set; }
};
}
