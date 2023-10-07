using BikeRentalSystem.Shared.Bike;

namespace BikeRentalSystem.Server.Features.Bikes.Services
{
    public interface IBikeService
    {
        Task<IReadOnlyList<BikeDto>> GetBikeListAsync(CancellationToken cancellationToken = default);
    }
}