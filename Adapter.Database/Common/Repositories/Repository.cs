using DomainApi.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using KSUID;

namespace Adapter.Database.Common.Repositories;

public abstract class Repository<TEntity>(DbContext context) : IRepository<TEntity>
    where TEntity : class
{
    public ValueTask<TEntity?> GetAsync(string id)
    {
        return context.Set<TEntity>().FindAsync(id);
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return context.Set<TEntity>().ToListAsync();
    }

    public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task AddRange(IEnumerable<TEntity> entities)
    {
        context.Set<TEntity>().AddRange(entities);
        await context.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteRange(IEnumerable<TEntity> entities)
    {
        context.Set<TEntity>().RemoveRange(entities);
        await context.SaveChangesAsync();
    }
}