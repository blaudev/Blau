using Blau.Entities;

namespace Blau.Data;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<bool> AnyAsync();
    Task<TEntity> FirstByIdAsync(int id);
    Task<TEntity?> FirstOrDefaultByIdAsync(int id);
    Task<List<TEntity>> ListAsync();
    Task AddAsync(TEntity entity);
    Task AddAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
