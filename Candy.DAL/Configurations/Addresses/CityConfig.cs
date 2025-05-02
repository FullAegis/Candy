using Candy.DAL.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Candy.DAL.Configurations.Addresses;
public class CityConfig : IEntityTypeConfiguration<City> {
  public void Configure(EntityTypeBuilder<City> builder) {
    builder.ToTable(nameof(City));
    builder.HasKey(c => c.PostCode);

    builder.Property(c => c.PostCode)
           .IsRequired()
           .ValueGeneratedNever()
           ;
    
    builder.Property(c => c.Name)
           .IsRequired()
           .HasColumnType("nvarchar(100)")
           .HasMaxLength(100)
           ;
  }
};
