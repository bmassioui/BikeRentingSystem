using Microsoft.AspNetCore.Components;

namespace BikeRentalSystem.Client.Pages.Bike;

public partial class UpdateBike
{
    [Parameter]
    public Guid Id { get; set; }
}
