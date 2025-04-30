namespace Candy.DAL.Interfaces.Products;
using Dal = Candy.DAL.Models.Products;

public interface IBrandRepository {
  IEnumerable<Dal::Brand> GetAll();
  Dal::Brand GetById(int id); 
  Dal::Brand GetByName(string name);
  void Add(Dal::Brand brand);
  void Update(Dal::Brand brand);
  void Delete(Dal::Brand brand);
};
