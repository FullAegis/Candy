using Microsoft.EntityFrameworkCore;

using Candy.DAL.Models;
using Candy.DAL.Models.Orders;
using Candy.DAL.Models.Products;

namespace Candy.DAL {
using CandyDbCtxOpts = DbContextOptions<CandyDbContext>;
using Candy = Models.Products.Candy;

public class CandyDbContext : DbContext {
  public DbSet<User> Users { get => Set<User>(); }
  public DbSet<Brand> Brands { get => Set<Brand>(); }
  public DbSet<Candy> Candies { get => Set<Candy>(); }
  public DbSet<Category> Categories { get => Set<Category>(); }
  public DbSet<Order> Orders { get => Set<Order>(); }
  public DbSet<OrderItem> OrderItems { get => Set<OrderItem>(); }
  
  public CandyDbContext(CandyDbCtxOpts options)
    : base(options)
  => Database.EnsureCreated(); 

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    var defaultConnection = Environment.GetEnvironmentVariable("Candy_DB__DefaultConnection");
    if (optionsBuilder.IsConfigured is false) {
      optionsBuilder.UseSqlServer(defaultConnection);
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
  }
};
}
