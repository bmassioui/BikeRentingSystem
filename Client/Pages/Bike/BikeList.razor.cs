using BikeRentalSystem.Client.Services.Client.Generated;
using BikeRentalSystem.Shared.Bike;
using Microsoft.AspNetCore.Components;

namespace BikeRentalSystem.Client.Pages.Bike;

public partial class BikeList
{
    [Inject]
    public IBikesClient BikesClient { get; set; } = default!;

    public IReadOnlyList<BikeDto> Bikes { get; set; } = Enumerable.Empty<BikeDto>().ToList();

    protected async override Task OnInitializedAsync()
    {
        Bikes = (IReadOnlyList<BikeDto>)await BikesClient.BikesAsync();
    }
}
