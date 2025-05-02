using Candy.DAL.Interfaces;
using Candy.DAL.Models.Addresses;

namespace Candy.DAL.Repositories.Addresses;

public class AddressRepository(CandyDbContext context) : IAddressRepository {
  private readonly CandyDbContext _context = context;
  
  public List<Address> GetAll() => _context.Addresses.ToList();

  public Address Get(int id) {
    var address = _context.Addresses.FirstOrDefault(a => a.Id == id);
    ArgumentNullException.ThrowIfNull(address);
    return address;
  }

  public void Add(in Address entity) {
    _context.Addresses.Add(entity);
    _context.SaveChanges();
  }

  public void Update(int id, in Address entity) {
    var addressToUpdate = Get(id);
    
    addressToUpdate.Id = id;
    addressToUpdate.Street = entity.Street;
    addressToUpdate.StreetSecondLine = entity.StreetSecondLine;
    addressToUpdate.PostCode = entity.PostCode;
    addressToUpdate.City = entity.City;
    addressToUpdate.Country = entity.Country;
    
    _context.SaveChanges();
  }

  public void Delete(in Address entity) {
    _context.Addresses.Remove(entity);
    _context.SaveChanges();
  }

  public void Delete(int id) {
    Delete(Get(id));
  }

  public List<Address> GetAll(ushort postCode) {
    var addresses = _context.Addresses.Where(a => a.PostCode == postCode);
    ArgumentNullException.ThrowIfNull(addresses);
    return addresses.ToList();
  }

  public List<Address> GetAll(string country) {
    var addresses = _context.Addresses.Where(a => a.Country == country);
    ArgumentNullException.ThrowIfNull(addresses);
    return addresses.ToList();
  }
};
