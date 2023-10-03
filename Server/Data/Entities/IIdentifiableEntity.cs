namespace BikeRentalSystem.Server.Data.Entities;

public interface IIdentifiableEntity<TId> where TId : struct
{
    public TId Id { get; set; }
}
