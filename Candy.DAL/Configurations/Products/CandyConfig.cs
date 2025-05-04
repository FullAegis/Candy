using Candy.DAL.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Dal = Candy.DAL.Models.Products;

namespace Candy.DAL.Configurations.Products;

public class CandyConfig : IEntityTypeConfiguration<Dal::Candy> {
  public void Configure(EntityTypeBuilder<Dal::Candy> builder) {
    builder.ToTable(nameof(Dal::Candy))
           ;
    builder.HasKey(x => x.Id)
           .HasName("PK_Candy")
           ;
    builder.Property(x => x.Name)
           .HasColumnName("Name")
           .HasColumnType("nvarchar(128)")
           .IsRequired()
           ;
    builder.Property(x => x.Description)
           .HasColumnName("Description")
           .HasColumnType("nvarchar(max)")
           .IsRequired(false)
           ;
    builder.Property(x => x.PriceBeforeTax)
           .HasColumnName("PriceBeforeTax")
           .HasColumnType("decimal(18, 2)")
           .IsRequired()
           ;
    builder.Property(x => x.StockQuantity)
           .HasColumnName("StockQuantity")
           .IsRequired()
           ;

#region Relationships
    builder.HasOne(c => c.Brand)
           .WithMany(b => b.Candies)
           .HasForeignKey(c => c.BrandId)
           .IsRequired()
           ;
    builder.HasOne(c => c.Category)
           .WithMany(cat => cat.Candies)
           .HasForeignKey(c => c.CategoryId)
           .IsRequired()
           ;
    builder.HasMany(c => c.OrderItems)
           .WithOne(oi => oi.Candy)
           .HasForeignKey(oi => oi.CandyId)
           ;
#endregion
  }
};
