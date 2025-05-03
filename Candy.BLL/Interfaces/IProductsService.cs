using Bll = Candy.BLL.Models.Products;

namespace Candy.BLL.Interfaces;
public interface IProductsService<T> where T : class {
  IEnumerable<T> GetAll();
  T Get(int id);
  
  void Create(in T product);
  void Update(int id, in T product);
  
  void Remove(int id);
  void Remove(in T product);
};

public interface IBrandService    : IProductsService<Bll::Brand>;
public interface ICategoryService : IProductsService<Bll::Category>;
public interface ICandyService    : IProductsService<Bll::Candy> {
  IList<Bll::Candy> GetAll(in Bll::Brand Brand);
  IList<Bll::Candy> GetAll(in Bll::Category category);
  
  void IncrementStock(int productId, uint newStock);
  void DecrementStock(int productId, uint quantity = 1);
  
  decimal TaxFreePrice(in Bll::Candy product);
  decimal TaxFreePrice(int id);
};
