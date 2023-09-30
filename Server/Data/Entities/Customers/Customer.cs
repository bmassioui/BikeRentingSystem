using BikeRentalSystem.Server.Data.ValueObjects;

namespace BikeRentalSystem.Server.Data.Entities.Customers;

public class Customer : BaseEntity<CustomerId>
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public Address Address { get; set; } = default!;

    public PhoneNumber Phone { get; set; } = default!;
}

