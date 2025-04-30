using Microsoft.EntityFrameworkCore;

using Candy.DAL.Models;
using Candy.DAL.Models.Products;

namespace Candy.DAL {
using CandyDbCtxOpts = DbContextOptions<CandyDbContext>;
using Candy = Models.Products.Candy;

public class CandyDbContext : DbContext {
  public DbSet<User> Users { get => Set<User>(); }
  public DbSet<Brand> Brands { get => Set<Brand>(); }
  public DbSet<Candy> Candies { get => Set<Candy>(); }
  
  public CandyDbContext(CandyDbCtxOpts options)
    : base(options)
  => Database.EnsureCreated(); 

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    if (optionsBuilder.IsConfigured is false)
      optionsBuilder.UseSqlServer(
        """
        Data Source=PC-BSTORM\MSSQLSERVER01;
        Initial Catalog=BookManager;
        Integrated Security=True;
        Connect Timeout=30;
        Encrypt=True;
        Trust Server Certificate=True;
        Application Intent=ReadWrite;
        Multi Subnet Failover=False
        """);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
  }
};
}
