using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeRentalSystem.Server.Data.Entities.Bikes;

public class BikeEntityConfiguration : IEntityTypeConfiguration<Bike>
{
    public void Configure(EntityTypeBuilder<Bike> builder)
    {
        builder
            .HasKey(bike => bike.Id);
        builder
            .Property(bike => bike.Id)
            .HasConversion(id => id.Value, guidValue => new BikeId(guidValue))
            .ValueGeneratedOnAdd();

        builder
            .Property(bike => bike.Title)
            .IsRequired()
            .HasMaxLength(40);

        builder
            .Property(bike => bike.ShortDescription)
            .IsRequired()
            .HasMaxLength(140);

        builder
            .Property(bike => bike.Price)
            .HasPrecision(10, 2);

        builder
            .Property(bike => bike.Type)
            .HasConversion<int>();

        builder
            .HasIndex(bike => bike.Type)
            .IsClustered(false);
    }
}
