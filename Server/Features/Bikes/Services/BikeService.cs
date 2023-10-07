using BikeRentalSystem.Server.Data;
using BikeRentalSystem.Server.Data.Entities.Bikes;
using BikeRentalSystem.Server.Features.Bikes.Mappers;
using BikeRentalSystem.Shared.Bike;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalSystem.Server.Features.Bikes.Services;

public class BikeService : IBikeService
{
    private readonly IApplicationDbContext _dbContext;

    public BikeService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<BikeDto>> GetBikeListAsync(CancellationToken cancellationToken = default)
    {
        List<Bike> bikes = await _dbContext.Bikes.ToListAsync(cancellationToken);

        return bikes.Select(bike => bike.ToBikeDto()).ToList();
    }
}
