using System.Linq.Expressions;

namespace Dominio.Interfaces;


public interface IGenericRepository<T>
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    IEnumerable<T> Find(Expression<Func<T,bool>> expression);
    Task<(int totalRegistros,IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search);

    void Update(T entity);
    void Remove (T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
}