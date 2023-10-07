using BikeRentalSystem.Server.Data;
using BikeRentalSystem.Server.Data.Interceptors;
using BikeRentalSystem.Server.Features.Bikes.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BikeRentalSystem.Server;

public static class ConfigureServices
{
    public static IServiceCollection AddBikeRentalSystemServerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditableEntitySaveChangesInterceptor>();

        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        ArgumentNullException.ThrowIfNull(connectionString);

        services.AddDbContext<BikeRentalSystemDbContext>((serviceProvider, options) =>
        {
            ConfigureDbContext(serviceProvider, options, connectionString);
        });

        services.AddScoped<IApplicationDbContext>(serviceProvider => serviceProvider.GetRequiredService<BikeRentalSystemDbContext>());

        services.AddScoped<ApplicationDbContextInitializer>();

        services.AddTransient<IBikeService, BikeService>();

        services.ConfigureSwaggerGen();

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

    private static IServiceCollection ConfigureSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Bike renting system API.",
                Description = "Bike Renting System API: Streamline your bike rental business with our powerful API. Manage bookings, track inventory, and offer a seamless rental experience to your customers.",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Bouchaib MASSIOUI",
                    Url = new Uri("https://www.linkedin.com/in/bouchaib-massioui/")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/license/mit/")
                }
            });

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}
