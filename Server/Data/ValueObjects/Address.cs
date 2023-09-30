namespace BikeRentalSystem.Server.Data.ValueObjects;

public sealed record Address(string District, string Street, uint HouseNumber, string ZipCode);