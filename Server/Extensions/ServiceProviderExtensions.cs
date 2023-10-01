using BikeRentalSystem.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalSystem.Server.Extensions;

public static class ServiceProviderExtensions
{
    public static void ApplyMigrations(this IServiceProvider service)
    {
        using var scope = service.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BikeRentalSystemDbContext>();
        db.Database.Migrate();
    }
}
