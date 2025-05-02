using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candy.DAL.Models.Addresses;
public class City {
  [Key] [Required] [Range(1000, 9992)] // ushort (16b) > ceil(log2(9992 - 1000)) = 14 
  public required ushort PostCode { get; set; }
  
  [Required] [Column(TypeName = "nvarchar(100)")]
  public required string Name { get; set; }
};
