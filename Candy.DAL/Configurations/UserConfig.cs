using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Candy.DAL.Models;

namespace Candy.DAL.Configurations {

  public class UserConfig : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
      builder.ToTable(nameof(User));

      builder.HasIndex(u => u.Email)
        .IsUnique()
        .HasDatabaseName("UK_Utilisateur_Email");

      builder.Property(u => u.Password)
        .HasColumnType("nvarchar(100)")
        .IsRequired();

      builder.Property(u => u.FirstName)
        .HasColumnType("nvarchar(100)")
        ;

      builder.Property(u => u.LastName)
        .HasColumnType("nvarchar(100)")
        ;
    }
  };
}
