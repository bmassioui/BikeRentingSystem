namespace BikeRentalSystem.Server.Data.Entities;

public class BaseEntity<T>
{
    public T Id { get; set; } = default!;
}
