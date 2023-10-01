using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeRentalSystem.Server.Data.Entities.Customers
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(customer => customer.Id);
            builder
                .Property(customer => customer.Id)
                .HasConversion(id => id.Value, uintValue => new CustomerId(uintValue))
                .ValueGeneratedOnAdd();

            builder
                .Property(customer => customer.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(customer => customer.LastName)
                .IsRequired()
                .HasMaxLength(20);

            builder
            .OwnsOne(customer => customer.Address);

            builder
            .OwnsOne(customer => customer.Phone);
        }
    }
}
