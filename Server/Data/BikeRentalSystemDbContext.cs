using BikeRentalSystem.Server.Data.Converters;
using BikeRentalSystem.Server.Data.Entities.Bikes;
using BikeRentalSystem.Server.Data.Entities.Customers;
using BikeRentalSystem.Server.Data.Entities.RentOrders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BikeRentalSystem.Server.Data;

public class BikeRentalSystemDbContext : DbContext, IApplicationDbContext
{
    public BikeRentalSystemDbContext(DbContextOptions<BikeRentalSystemDbContext> dbContextOptions) : base(dbContextOptions)
    { }

    public DbSet<Bike> Bikes => Set<Bike>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<RentOrder> RentOrders => Set<RentOrder>();

    public DbSet<LineItem> LineItems => Set<LineItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder
            .Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }
}
