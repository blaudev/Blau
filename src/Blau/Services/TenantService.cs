using Microsoft.AspNetCore.Http;

namespace Blau.Services;

public class TenantService(IHttpContextAccessor httpContextAccessor) : ITenantService
{
    public Guid GetTenantId()
    {
        var httpContext = httpContextAccessor.HttpContext;

        return new Guid("8D3ED982-10B2-433F-9B83-9BA0B9811136");
    }

    public Guid GetTenantIdByQueryString()
    {
        return new Guid("8D3ED982-10B2-433F-9B83-9BA0B9811136");
    }
}
