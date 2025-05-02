using Candy.DAL.Interfaces;
using Candy.DAL.Models.Addresses;

namespace Candy.DAL.Repositories.Addresses;

public class CityRepository(CandyDbContext context) : ICityRepository {
  private readonly CandyDbContext _context = context;
  
  public List<City> GetAll() => _context.Cities.ToList();
  
  public City Get(ushort postCode) {
    var city = _context.Cities.FirstOrDefault(c => c.PostCode == postCode);
    ArgumentNullException.ThrowIfNull(city);
    return city;
  }

  public City Get(string name) {
    var city = _context.Cities.FirstOrDefault(c => c.Name == name);
    ArgumentNullException.ThrowIfNull(city);
    return city;
  }

  public void Add(in City city) {
    _context.Cities.Add(city);
    _context.SaveChanges();
  }

  public void Update(ushort id, in City city) {
    var cityToUpdate = Get(id);
    
    cityToUpdate.Name = city.Name;
    cityToUpdate.PostCode = city.PostCode;
    
    _context.SaveChanges();
  }

  public void Delete(in City city) {
    _context.Cities.Remove(city);
    _context.SaveChanges();
  }

  public void Delete(ushort postCode) {
    Delete(Get(postCode));
  }
}
