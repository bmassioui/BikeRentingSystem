using BikeRentalSystem.Shared.Enumerations;

namespace BikeRentalSystem.Server.Data.Entities.Bikes;

public class Bike : BaseEntity<BikeId>
{
    public string Title { get; set; } = default!;

    public string ShortDescription { get; set; } = default!;

    public string FullDescription { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    public BikeType Type { get; set; }

    public string? ThumbnailImageUrl { get; set; }

    public string? ImageUrl { get; set; }
}
