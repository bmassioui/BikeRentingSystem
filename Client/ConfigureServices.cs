using BikeRentalSystem.Client.Services.Client.Generated;
using System.Net.Http.Headers;

namespace BikeRentalSystem.Client;

public static class ConfigureServices
{
    public static IServiceCollection AddBikeRentalSystemClientServices(this IServiceCollection services)
    {
        services.AddHttpClient<IBikesClient, BikesClient>((serviceProvider, httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://localhost:7092/api/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

        return services;
    }
}