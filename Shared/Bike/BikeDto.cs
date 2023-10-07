namespace BikeRentalSystem.Shared.Bike;

public record BikeDto(
    Guid Id, 
    string Title, 
    string ShortDescription, 
    string FullDescription, 
    decimal Price, 
    bool IsAvailable, 
    string? ThumbnailImageUrl, 
    string? ImageUrl);
