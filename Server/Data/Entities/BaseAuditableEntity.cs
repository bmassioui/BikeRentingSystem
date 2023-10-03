namespace BikeRentalSystem.Server.Data.Entities;

public abstract class BaseAuditableEntity
{
    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }
}
