using Blau.Entities;

using Microsoft.EntityFrameworkCore;

namespace Blau.Data;

public class NamedRepository<TDataContext, TNamedEntity>(TDataContext context)
    : Repository<TDataContext, TNamedEntity>(context), INamedRepository<TNamedEntity>
        where TDataContext : DataContext
        where TNamedEntity : class, INamedEntity
{
    public async Task<TNamedEntity> FirstByNameAsync(string name)
    {
        return await Set.FirstAsync(q => q.Name == name);
    }

    public async Task<TNamedEntity?> FirstOrDefaultByNameAsync(string name)
    {
        return await Set.FirstOrDefaultAsync(q => q.Name == name);
    }
}
