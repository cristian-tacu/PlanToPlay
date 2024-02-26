using Hangfire;
using Hangfire.MySql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Adapter.Hangfire;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddAdapterHangfireServices(
        this IServiceCollection services,
        string hangfireConnectionString
        )
    {
        services.AddHangfire(config =>
        {
            config.UseStorage(new MySqlStorage(hangfireConnectionString,
                new MySqlStorageOptions
                {
                    QueuePollInterval = TimeSpan.FromSeconds(10),
                    JobExpirationCheckInterval = TimeSpan.FromHours(1),
                    CountersAggregateInterval = TimeSpan.FromMinutes(5),
                    PrepareSchemaIfNecessary = true,
                    DashboardJobListLimit = 25000,
                    TransactionTimeout = TimeSpan.FromMinutes(1),
                    TablesPrefix = "Hangfire"
                }));
        });

        services.AddHangfireServer();

        return services;
    }

    public static IApplicationBuilder UseAdapterHangfire(this IApplicationBuilder app)
    {
        app.UseHangfireDashboard();

        return app;
    }
}
