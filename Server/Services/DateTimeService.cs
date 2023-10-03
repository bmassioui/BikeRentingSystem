using BikeRentalSystem.Server.Interfaces;

namespace BikeRentalSystem.Server.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
