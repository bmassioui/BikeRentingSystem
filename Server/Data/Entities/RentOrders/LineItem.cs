using BikeRentalSystem.Server.Data.Entities.Bikes;

namespace BikeRentalSystem.Server.Data.Entities.RentOrders;

public class LineItem : BaseEntity<LineItemId>
{
    public uint Quantity { get; set; }

    public BikeId BikeId { get; set; }
    public virtual Bike Bike { get; set; } = default!;

    public RentOrderId RentOrderId { get; set; }
    public virtual RentOrder RentOrder { get; set; } = default!;
}
