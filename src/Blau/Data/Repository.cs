using Blau.Entities;

using Microsoft.EntityFrameworkCore;

namespace Blau.Data;

public class Repository<TDataContext, TEntity>(TDataContext context)
    : IRepository<TEntity>
        where TDataContext : DataContext
        where TEntity : class, IEntity
{
    protected DbSet<TEntity> Set => context.Set<TEntity>();

    public async Task<bool> AnyAsync()
    {
        return await Set.AnyAsync();
    }

    public async Task<TEntity> FirstByIdAsync(int id)
    {
        return await Set.FirstAsync(q => q.Id == id);
    }

    public async Task<TEntity?> FirstOrDefaultByIdAsync(int id)
    {
        return await Set.FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<List<TEntity>> ListAsync()
    {
        return await Set.ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Set.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task AddAsync(IEnumerable<TEntity> entities)
    {
        await Set.AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Set.Remove(entity);
        await context.SaveChangesAsync();
    }
}
