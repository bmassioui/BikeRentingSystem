using BikeRentalSystem.Server.Data.Entities.Customers;

namespace BikeRentalSystem.Server.Data.Entities.RentOrders;

public class RentOrder : BaseEntity<RentOrderId>
{
    public DateOnly RentDate { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public decimal Total { get; set; }

    public CustomerId CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = default!;

    public virtual ICollection<LineItem> LineItems { get; set; } = Enumerable.Empty<LineItem>().ToList();
}
