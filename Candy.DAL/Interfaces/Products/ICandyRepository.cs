namespace Candy.DAL.Interfaces.Products;
using Dal = Candy.DAL.Models.Products;

public interface ICandyRepository {
  List<Dal::Candy> GetAll();
  List<Dal::Candy> GetAll(Dal::Category category);
  List<Dal::Candy> GetAll(Dal::Brand brand);
  
  Dal::Candy Get(int id); 
  Dal::Candy Get(string name);
  
  void Add(in Dal::Candy candy);
  void Update(int id, in Dal::Candy candy);
  void Delete(in Dal::Candy candy);
  void Delete(int id);
};
