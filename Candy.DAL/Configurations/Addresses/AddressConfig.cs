using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Candy.DAL.Models.Addresses;

namespace Candy.DAL.Configurations.Addresses;
public class AddressConfiguration : IEntityTypeConfiguration<Address> {
  public void Configure(EntityTypeBuilder<Address> builder) {
    builder.ToTable(nameof(Address));
    
    builder.HasKey(a => a.Id);
    builder.Property(a => a.Id)
           .ValueGeneratedOnAdd()
           ;
    
    builder.Property(a => a.Street)
           .IsRequired()
           .HasColumnType("nvarchar(200)")
           .HasMaxLength(200)
           ;
    
    builder.Property(a => a.StreetSecondLine)
           .HasColumnType("nvarchar(200)")
           .HasMaxLength(200)
           ;
    
    builder.Property(a => a.PostCode)
           .IsRequired()
           ;
    
    builder.Property(a => a.Country)
           .IsRequired()
           .HasMaxLength(200)
           .HasDefaultValue("Belgium")
           ;

#region Relationships
    builder.HasOne(a => a.City) // [Address] 1 —— Has —— 1 [City]  
           .WithMany()          //    [City] 1 —— Has —— * [Address]  
           .HasForeignKey(a => a.PostCode)
           .IsRequired()
           ;
    builder.HasIndex(a => a.PostCode);
    builder.HasIndex(a => a.Country);
#endregion
  }
};
