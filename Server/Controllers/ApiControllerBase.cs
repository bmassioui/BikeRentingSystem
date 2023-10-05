using Microsoft.AspNetCore.Mvc;

namespace BikeRentalSystem.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public abstract class ApiControllerBase : ControllerBase
{ }
