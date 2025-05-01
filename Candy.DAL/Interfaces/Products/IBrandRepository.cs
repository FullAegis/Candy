namespace Candy.DAL.Interfaces.Products;
using Dal = Candy.DAL.Models.Products;

public interface IBrandRepository {
  List<Dal::Brand> GetAll();
  Dal::Brand Get(int id); 
  Dal::Brand Get(string name);
  void Add(Dal::Brand brand);
  void Update(int id, Dal::Brand brand);
  void Delete(Dal::Brand brand);
  void Delete(int id);
};
