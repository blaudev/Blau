using Blau.UseCases;

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

        services.AddDbContext<TDatabaseContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        var useCaseTypes = services
            .GetType()
            .Assembly
            .GetTypes()
            .Where(type => type.IsClass && type.IsAssignableTo(typeof(IUseCaseHandler)))
            .ToList();

        useCaseTypes.ForEach(useCase =>
        {
            services.AddScoped(typeof(IUseCaseHandler), useCase);
        });

        return services;
    }
}
