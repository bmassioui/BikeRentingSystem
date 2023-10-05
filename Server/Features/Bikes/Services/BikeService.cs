using BikeRentalSystem.Server.Data;
using BikeRentalSystem.Server.Data.Entities.Bikes;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalSystem.Server.Features.Bikes.Services;

public class BikeService : IBikeService
{
    private readonly IApplicationDbContext _dbContext;

    public BikeService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Bike>> GetBikeListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Bikes.ToListAsync(cancellationToken);
    }
}
