using BikeRentalSystem.Server.Data.Entities.Bikes;
using BikeRentalSystem.Server.Data.Entities.Customers;
using BikeRentalSystem.Shared.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BikeRentalSystem.Server.Data;

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication application, CancellationToken cancellationToken = default)
    {
        using var scope = application.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();

        await initialiser.InitializeAsync(cancellationToken);

        await initialiser.SeedAsync(cancellationToken);
    }
}

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly BikeRentalSystemDbContext _dbContext;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, BikeRentalSystemDbContext dbContext)
        => (_logger, _dbContext) = (logger, dbContext);

    internal async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbContext.Database.MigrateAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "An error occurred while initializing the database.");
            throw;
        }
    }

    internal async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        // Customer
        if (!_dbContext.Customers.Any())
        {
            var customers = GenerateCustomerList();

            await _dbContext.Customers.AddRangeAsync(customers, cancellationToken);
        }

        // Bikes
        if (!_dbContext.Bikes.Any())
        {
            var bikes = GenerateBikeList();

            await _dbContext.Bikes.AddRangeAsync(bikes, cancellationToken);
        }

        IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await _dbContext.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            await transaction.RollbackAsync(cancellationToken);

            _logger.LogError(exception, "An error occurred while seeding the database.");
            throw;
        }
    }

    private static IReadOnlyList<Customer> GenerateCustomerList()
    {
        var customers = new List<Customer>()
        {
            new()
            {
                FirstName = "George",
                LastName = "Roberson",
                Email = "george.roberson@outlook.com",
                Address = new("Glendale", "3354 New York Avenue", 78, "91204"),
                Phone = new("(717)", 762, 521, 0356)
            }
        };

        return customers.AsReadOnly();
    }

    private static IReadOnlyList<Bike> GenerateBikeList()
    {
        var bikes = new List<Bike>
        {
            new()
            {
                Title = "Road Bike",
                ShortDescription = "Sleek and speedy road bike built for performance. Carbon fiber frame, aerodynamic design, and precision components.",
                FullDescription = "The Sleek and Speedy Road Bike is the epitome of high-performance cycling, meticulously crafted to offer riders an exceptional experience on the road. Designed for speed enthusiasts and those seeking top-tier performance, this road bike embodies precision engineering and advanced technology.",
                Price = 15.92M,
                IsAvailable = true,
                Type = BikeType.ROAD,
                ThumbnailImageUrl = "images/bike/lowside.jpg",
                ImageUrl = "images/bike/lowside.jpg",
            },
            new()
            {
                Title = "Aventon Mataro Electric Bike",
                ShortDescription = "The Aventon Mataro Electric Bike combines the sleek and stylish design of the Mataro with the convenience and power of electric assistance.",
                FullDescription = "The Aventon Mataro Electric Bike is a cutting-edge and stylish electric bicycle that combines modern design with high-performance features. Designed to provide an efficient and eco-friendly mode of transportation, this electric bike offers a seamless blend of technology and functionality.",
                Price = 45.00M,
                IsAvailable = true,
                Type = BikeType.ELECTRIC,
                ThumbnailImageUrl = "images/bike/aventon-mataro.jpg",
                ImageUrl = "images/bike/aventon-mataro.jpg",
            },
            new()
            {
                Title = "Rockhopper",
                ShortDescription = "The Rockhopper is a rugged and versatile mountain bike built to conquer the trails. With its durable frame and precision components.",
                FullDescription = "The Rockhopper is the ultimate companion for off-road enthusiasts and trail conquerors. This rugged mountain bike is meticulously crafted to handle the toughest terrains with ease. Its durable frame, designed to withstand the rigors of off-road adventures, provides both stability and agility.",
                Price = 65.24M,
                IsAvailable = true,
                Type = BikeType.MOUNTAIN,
                ThumbnailImageUrl = null,
                ImageUrl = null,
            },
            new()
            {
                Title = "Electric bike",
                ShortDescription = "Eco-friendly and high-performance electric bikes offer you the perfect blend of pedal power and electric assistance.",
                FullDescription = "Discover the world of eco-friendly and high-performance electric bikes that offer a seamless blend of pedal power and electric assistance. These bikes are designed to make your journeys smooth, efficient, and enjoyable.",
                Price = 30.22M,
                IsAvailable = false,
                Type = BikeType.ELECTRIC,
                ThumbnailImageUrl = "images/bike/propella.jpeg",
                ImageUrl = "images/bike/propella.jpeg",
            },
            new()
            {
                Title = "Radio Legion",
                ShortDescription = "The Radio Legion 26 is a versatile electric bike designed for all-terrain adventures. With its rugged build and powerful electric motor.",
                FullDescription = "The Radio Legion 26 is your gateway to all-terrain adventures, combining rugged durability with the power of electric assistance. This versatile electric bike is meticulously designed to tackle any terrain you throw at it, making it the perfect companion for outdoor enthusiasts and thrill-seekers.",
                Price = 23.11M,
                IsAvailable = true,
                Type = BikeType.ELECTRIC,
                ThumbnailImageUrl = "images/bike/radio-legion.jpg",
                ImageUrl = "images/bike/radio-legion.jpg",
            }
        };

        return bikes.AsReadOnly();
    }
}
