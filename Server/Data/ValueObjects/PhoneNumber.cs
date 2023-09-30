namespace BikeRentalSystem.Server.Data.ValueObjects;

public sealed record PhoneNumber(string InternationalPrefix, uint CountryCode, uint NationalPrefix, uint LocalNumber);