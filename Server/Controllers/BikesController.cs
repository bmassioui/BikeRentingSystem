using BikeRentalSystem.Server.Features.Bikes.Services;
using BikeRentalSystem.Shared.Bike;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalSystem.Server.Controllers;

public class BikesController : ApiControllerBase
{
    private readonly IBikeService _bikeService;

    public BikesController(IBikeService bikeService)
    {
        _bikeService = bikeService;
    }

    /// <summary>
    /// Get list of bike
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Returns list of bike</response>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IEnumerable<BikeDto>>> GetBikeList(CancellationToken cancellationToken = default)
    {
        return Ok(await _bikeService.GetBikeListAsync(cancellationToken));
    }
}
