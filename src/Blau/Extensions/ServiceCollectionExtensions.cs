using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blau.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDefaultOpenApiServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddDefaultDatabaseContext<TDatabaseContext>(this IServiceCollection services, IConfiguration configuration)
        where TDatabaseContext : DbContext
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<TDatabaseContext>(options => options.UseNpgsql(connectionString));
        return services;
    }

    public static IServiceCollection AddUseCaseHandlers(this IServiceCollection services)
    {
        var assembly = Assembly.GetEntryAssembly() ?? throw new InvalidOperationException();
        assembly.GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("UseCaseHandler"))
            .Select(x => (Abstraction: x.GetInterfaces().First(q => q.Name == $"I{x.Name}"), Implementation: x))
            .ToList()
            .ForEach(x =>
            {
                services.AddScoped(x.Abstraction, x.Implementation);
            });

        return services;
    }
}
