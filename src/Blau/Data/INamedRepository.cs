using Blau.Entities;

namespace Blau.Data;

public interface INamedRepository<TNamedEntity> : IRepository<TNamedEntity>
    where TNamedEntity : INamedEntity
{
    Task<TNamedEntity> FirstByNameAsync(string name);
    Task<TNamedEntity?> FirstOrDefaultByNameAsync(string name);
}
