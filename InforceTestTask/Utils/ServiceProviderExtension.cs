using InforceTestTask.Services;
using InforceTestTask.Services.Interfaces;

namespace InforceTestTask.Utils;

internal static class ServiceProviderExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IShortUrlGenerator, ShortUrlGenerator>();
        services.AddHttpContextAccessor();
    }
}