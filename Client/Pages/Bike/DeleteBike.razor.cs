using Microsoft.AspNetCore.Components;

namespace BikeRentalSystem.Client.Pages.Bike;

public partial class DeleteBike
{
    [Parameter]
    public Guid Id { get; set; }
}
