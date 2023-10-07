using BikeRentalSystem.Server.Data.Entities.Bikes;
using BikeRentalSystem.Shared.Bike;

namespace BikeRentalSystem.Server.Features.Bikes.Mappers;

public static class BikeMappers
{
    internal static BikeDto ToBikeDto(this Bike bike)
    {
        return
            new BikeDto(
                bike.Id.Value,
                bike.Title,
                bike.ShortDescription,
                bike.FullDescription,
                bike.Price,
                bike.IsAvailable,
                bike.ThumbnailImageUrl,
                bike.ImageUrl);
    }
}
