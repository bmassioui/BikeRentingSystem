using BikeRentalSystem.Server.Data;
using BikeRentalSystem.Server.Data.Interceptors;
using BikeRentalSystem.Server.Interfaces;
using BikeRentalSystem.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BikeRentalSystem.Server;

public static class ConfigureServices
{
    public static IServiceCollection AddBikeRentalSystemServerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditableEntitySaveChangesInterceptor>();

        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<BikeRentalSystemDbContext>((serviceProvider, options) =>
        {
            ConfigureDbContext(serviceProvider, options, connectionString);
        });

        services.AddTransient<IDateTime, DateTimeService>();

        services.AddScoped<ApplicationDbContextInitializer>();

        return services;
    }

    private static void ConfigureDbContext(IServiceProvider serviceProvider, DbContextOptionsBuilder options, string connectionString)
    {
        options.UseSqlServer(connectionString);
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        ISaveChangesInterceptor? interceptors = serviceProvider.GetService<ISaveChangesInterceptor>();

        if (interceptors == default) return;

        options.AddInterceptors(interceptors);
    }
}
