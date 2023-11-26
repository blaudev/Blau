using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace Blau.Data;

public class DataContext<TDataContext>(DbContextOptions<TDataContext> options) : DbContext(options)
    where TDataContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
