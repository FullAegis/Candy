using Candy.DAL.Interfaces.Products; // IBrandRepository
using Candy.DAL.Models.Products;

namespace Candy.DAL.Repositories.Products;

public class BrandRepository : IBrandRepository {
  private readonly CandyDbContext _context;
  
  public List<Brand> GetAll() => _context.Brands.ToList();

  public Brand Get(int id) {
    var brand = _context.Brands.FirstOrDefault(b => b.Id == id);
    ArgumentNullException.ThrowIfNull(brand);
    return brand;
  }

  public Brand Get(string name) {
    var brand = _context.Brands.FirstOrDefault(b => b.Name == name);
    ArgumentNullException.ThrowIfNull(brand);
    return brand;
  }

  public void    Add(Brand brand) => _context.Brands.Add(brand);
  public void Update(Brand brand) => _context.Brands.Update(brand);
  public void Delete(Brand brand) => _context.Brands.Remove(brand);
  
};
