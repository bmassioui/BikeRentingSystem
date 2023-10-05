using BikeRentalSystem.Server.Data.Entities.Bikes;

namespace BikeRentalSystem.Server.Features.Bikes.Services
{
    public interface IBikeService
    {
        Task<IReadOnlyList<Bike>> GetBikeListAsync(CancellationToken cancellationToken = default);
    }
}