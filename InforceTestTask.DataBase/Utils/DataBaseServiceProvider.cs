using InforceTestTask.DataBase.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InforceTestTask.DataBase.Utils;

public static class DataBaseServiceProvider
{
    private const string ConnectionStringKey = "MSSQL";
    private const string ConnectionStringErrorMessage = $"Connection string '{ConnectionStringKey}' not found.";

    public static void AddDataBaseServices(this IServiceCollection services)
    {
        string connectionString = services
            .BuildServiceProvider()
            .GetRequiredService<IConfiguration>()
            .GetConnectionString(ConnectionStringKey)
                                    ?? throw new InvalidOperationException(ConnectionStringErrorMessage);

        services.AddDbContext<InforceDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}
