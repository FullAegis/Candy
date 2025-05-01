namespace Candy.DAL.Interfaces.Products;
using Dal = Candy.DAL.Models.Products;

public interface ICategoryRepository {
  List<Dal::Category> GetAll();
  Dal::Category Get(int id); 
  Dal::Category Get(string name);
  void Add(in Dal::Category category);
  void Update(int id, in Dal::Category category);
  void Delete(in Dal::Category category);
  void Delete(int id);
};
