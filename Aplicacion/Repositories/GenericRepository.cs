using System.Linq.Expressions;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{


    protected readonly InsidenciasContext _context;
    public GenericRepository(InsidenciasContext context)
    {
        _context = context;
    }
    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }


    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
       return  _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
       return await _context.Set<T>().FindAsync(id);
    }

    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}