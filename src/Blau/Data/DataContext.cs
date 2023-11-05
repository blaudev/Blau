using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace Blau.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    // EntityFramework required constructor
    public DataContext() : this(default!) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
