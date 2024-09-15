using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using nheejods.Contexts;
using nheejods.Repositories.Interfaces;

namespace nheejods.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{

    public DbSet<T> DbSet { get; private set; }

    public BaseRepository(MySQLDbContext dbContext)
    {
        this.DbSet = dbContext.Set<T>();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> expression)
    {
        return this.DbSet.Where(expression);
    }

    public async Task<T?> FindByIdAsync<N>(N id)
    {
        return await this.DbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await this.DbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        this.DbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        this.DbSet.Remove(entity);
    }

    public void RemoveRange(List<T> entities)
    {
        this.DbSet.RemoveRange(entities);
    }
}
