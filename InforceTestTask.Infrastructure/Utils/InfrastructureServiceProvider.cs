using InforceTestTask.Infrastructure.Services;
using InforceTestTask.Infrastructure.Services.Interfaces;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace InforceTestTask.Infrastructure.Utils;

public static class InfrastructureServiceProvider
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMapster();
        services.AddScoped<IShortUrlMapper, ShortUrlMapper>();
        services.AddScoped<IShortUrlService, ShortUrlService>();
    }
}
