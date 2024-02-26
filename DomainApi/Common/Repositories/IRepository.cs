using System.Linq.Expressions;
using KSUID;

namespace DomainApi.Common.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    ValueTask<TEntity?> GetAsync(string id);
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    Task Add(TEntity entity);
    Task AddRange(IEnumerable<TEntity> entities);

    Task Delete(TEntity entity);
    Task DeleteRange(IEnumerable<TEntity> entities);
}
