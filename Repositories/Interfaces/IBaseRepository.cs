using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace nheejods.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    public DbSet<T> DbSet { get; }
    IQueryable<T> Find(Expression<Func<T, bool>> expression);
    Task<T?> FindByIdAsync<N>(N id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(List<T> entities);
}
