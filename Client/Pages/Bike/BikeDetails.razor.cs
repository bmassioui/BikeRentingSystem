using Microsoft.AspNetCore.Components;

namespace BikeRentalSystem.Client.Pages.Bike;

public partial class BikeDetails
{
    [Parameter]
    public Guid Id { get; set; }
}
