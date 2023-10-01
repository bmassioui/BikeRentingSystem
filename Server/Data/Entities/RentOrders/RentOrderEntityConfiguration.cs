using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeRentalSystem.Server.Data.Entities.RentOrders
{
    public class RentOrderEntityConfiguration : IEntityTypeConfiguration<RentOrder>
    {
        public void Configure(EntityTypeBuilder<RentOrder> builder)
        {
            builder
                .HasKey(rentOrder => rentOrder.Id);
            builder
                .Property(rentOrder => rentOrder.Id)
                .HasConversion(id => id.Value, uintValue => new RentOrderId(uintValue))
                .ValueGeneratedOnAdd();

            builder
                .Property(rentOrder => rentOrder.Total)
                .HasPrecision(10,2);

            builder
                .HasOne(rentOrder => rentOrder.Customer)
                .WithMany(customer => customer.RentOrders)
                .HasForeignKey(rentOrder => rentOrder.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
