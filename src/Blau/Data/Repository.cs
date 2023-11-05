using Blau.Entities;

using Microsoft.EntityFrameworkCore;

namespace Blau.Data;

public class Repository<TDataContext, TEntity>(TDataContext context)
    : IRepository<TEntity>
        where TDataContext : DataContext
        where TEntity : class, IEntity
{
    protected TDataContext Context { get; } = context;

    public async Task<bool> AnyAsync()
    {
        return await Context.Set<TEntity>().AnyAsync();
    }

    public async Task<TEntity> FirstByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FirstAsync(q => q.Id == id);
    }

    public async Task<TEntity?> FirstOrDefaultByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<List<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task AddAsync(IEnumerable<TEntity> entities)
    {
        await Context.Set<TEntity>().AddRangeAsync(entities);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync();
    }
}
