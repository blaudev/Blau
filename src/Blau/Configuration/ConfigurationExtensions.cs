using Blau.Exceptions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blau.Configuration;

public static class ConfigurationExtensions
{
    public static T ConfigureRequiredOptions<T>(this IServiceCollection services, IConfiguration configuration)
        where T : class, IOptions
    {
        var section = configuration.GetRequiredSection(T.SectionName);
        services.Configure<T>(section);
        return section.Get<T>() ?? throw new ValidationException(nameof(T));
    }
}
