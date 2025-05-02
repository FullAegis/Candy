using Candy.DAL.Models.Addresses;

namespace Candy.DAL.Interfaces;
public interface IAddressRepository : IRepository<Address> {
  List<Address> GetAll(ushort postCode);
  List<Address> GetAll(string country);
};

public interface ICityRepository {
  List<City> GetAll();
  City Get(ushort postCode); 
  City Get(string name);
  void Add(in City city);
  void Update(ushort id, in City city);
  void Delete(in City city);
  void Delete(ushort postCode);
};
