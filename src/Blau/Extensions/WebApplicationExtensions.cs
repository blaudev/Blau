using Microsoft.AspNetCore.Builder;

namespace Blau.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseDefaultOpenApiApplications(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
