using BikeRentalSystem.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalSystem.Server;

public static class ConfigureServices
{
    public static IServiceCollection AddBikeRentalSystemServerServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<BikeRentalSystemDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
