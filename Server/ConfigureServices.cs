using BikeRentalSystem.Server.Data;
using BikeRentalSystem.Server.Data.Interceptors;
using BikeRentalSystem.Server.Interfaces;
using BikeRentalSystem.Server.Services;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalSystem.Server;

public static class ConfigureServices
{
    public static IServiceCollection AddBikeRentalSystemServerServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<BikeRentalSystemDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddTransient<IDateTime, DateTimeService>();

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        return services;
    }
}
