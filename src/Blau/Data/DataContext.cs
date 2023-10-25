using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace Blau.Data;

public class DataContext<T>(DbContextOptions<T> options) : DbContext(options)
    where T : DbContext
{
    // EntityFramework required constructor
    public DataContext() : this(default!) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}
