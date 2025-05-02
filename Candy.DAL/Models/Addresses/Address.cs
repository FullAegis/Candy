using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candy.DAL.Models.Addresses;
public class Address {
  [Required]
  public int Id { get; set; }
  
  [Required] [Column(TypeName = "nvarchar(200)")]
  public required string Street { get; set; }
  [Column(TypeName = "nvarchar(200)")]
  public string StreetSecondLine { get; set; } = string.Empty;
  
  [Required] [Range(1000, 9992)] // ushort (16b) > ceil(log2(9992 - 1000)) = 14 
  public required ushort PostCode { get; set; }
  
  [ForeignKey("PostCode")]
  public City City { get; set; }
  
  [Required] [Column(TypeName = "nvarchar(200)")]
  public string Country { get; set; } = "Belgium";
};
