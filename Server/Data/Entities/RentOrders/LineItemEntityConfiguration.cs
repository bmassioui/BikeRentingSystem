using BikeRentalSystem.Server.Data.Entities.RentOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeRentalSystem.Server.Data.Entities.lineItems
{
    public class LineItemEntityConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder
               .HasKey(lineItem => lineItem.Id);
            builder
                .Property(lineItem => lineItem.Id)
                .HasConversion(id => id.Value, uintValue => new LineItemId(uintValue))
                .ValueGeneratedOnAdd();

            builder
                .ToTable(lineItem => lineItem.HasCheckConstraint("CK_LineItem_Quantity", "[Quantity] > 0"));

            builder
                .HasOne(lineItem => lineItem.Bike)
                .WithMany(bike => bike.LineItems)
                .HasForeignKey(lineItem => lineItem.BikeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(lineItem => lineItem.RentOrder)
                .WithMany(rentOrder => rentOrder.LineItems)
                .HasForeignKey(lineItem => lineItem.RentOrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
