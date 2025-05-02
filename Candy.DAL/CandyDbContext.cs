using Microsoft.EntityFrameworkCore;

using Candy.DAL.Models;
using Candy.DAL.Models.Addresses;
using Candy.DAL.Models.Orders;
using Candy.DAL.Models.Products;

namespace Candy.DAL {
using CandyDbCtxOpts = DbContextOptions<CandyDbContext>;
using Candy = Models.Products.Candy;

public class CandyDbContext : DbContext {
  public DbSet<City> Cities { get => Set<City>(); }
  public DbSet<Address> Addresses { get => Set<Address>(); }
  
  public DbSet<User> Users { get => Set<User>(); }
  // public DbSet<Customer> Customers { get => Set<Customer>(); }
  
  public DbSet<Brand> Brands { get => Set<Brand>(); }
  public DbSet<Candy> Candies { get => Set<Candy>(); }
  public DbSet<Category> Categories { get => Set<Category>(); }
  
  public DbSet<Order> Orders { get => Set<Order>(); }
  public DbSet<OrderItem> OrderItems { get => Set<OrderItem>(); }
  
  
  public CandyDbContext(CandyDbCtxOpts options)
    : base(options)
  => Database.EnsureCreated(); 

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
#warning Connection String Is Placeholder !
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
