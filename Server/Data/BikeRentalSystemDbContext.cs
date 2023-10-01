using BikeRentalSystem.Server.Data.Converters;
using BikeRentalSystem.Server.Data.Entities.Bikes;
using BikeRentalSystem.Server.Data.Entities.Customers;
using BikeRentalSystem.Server.Data.Entities.RentOrders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BikeRentalSystem.Server.Data;

public class BikeRentalSystemDbContext : DbContext
{
    public BikeRentalSystemDbContext(DbContextOptions<BikeRentalSystemDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Bike> Bikes { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<RentOrder> RentOrders { get; set; }

    public DbSet<LineItem> LineItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // The order doesn't matter : https://learn.microsoft.com/en-us/ef/core/modeling/#applying-all-configurations-in-an-assembly
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
