using InforceTestTask.Infrastructure.Services;
using InforceTestTask.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InforceTestTask.Infrastructure.Utils;

public static class InfrastructureServiceProvider
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IShortUrlService, ShortUrlService>();
    }
}
