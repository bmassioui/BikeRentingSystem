using BikeRentalSystem.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalSystem.Server.Extensions;

public static class ServiceProviderExtensions
{
    public static async Task ApplyMigrationsAsync(this IServiceProvider service, CancellationToken cancellationToken = default)
    {
        using var scope = service.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BikeRentalSystemDbContext>();

        await db.Database.MigrateAsync(cancellationToken);
    }
}
