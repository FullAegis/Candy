namespace Candy.DAL.Interfaces;

public interface IRepository<T> where T : class {
  IList<T> GetAll();
  T Get(int id); 
  void Add(in T entity);
  void Update(int id, in T entity);
  void Delete(in T entity);
  void Delete(int id);
};
