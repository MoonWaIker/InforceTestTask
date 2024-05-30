using InforceTestTask.Context;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.Utils;

internal static class DbContextProvider
{
    private const string ConnectionStringName = "DefaultConnection";

    internal static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InforceDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString(ConnectionStringName));
        });
    }
}