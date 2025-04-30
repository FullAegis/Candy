using Candy.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Candy.DAL {
using CandyDbCtxOpts = DbContextOptions<CandyDbContext>;
public class CandyDbContext : DbContext {
  public DbSet<User> Users { get => Set<User>(); }
  
  public CandyDbContext(CandyDbCtxOpts options)
    : base(options)
  => Database.EnsureCreated();

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    optionsBuilder.UseSqlServer(@"");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
  }
};
}
