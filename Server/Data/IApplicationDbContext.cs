using BikeRentalSystem.Server.Data.Entities.Bikes;
using BikeRentalSystem.Server.Data.Entities.Customers;
using BikeRentalSystem.Server.Data.Entities.RentOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BikeRentalSystem.Server.Data;

public interface IApplicationDbContext
{
    DbSet<Bike> Bikes { get; }

    DbSet<Customer> Customers { get; }

    DbSet<RentOrder> RentOrders { get; }

    DbSet<LineItem> LineItems { get; }

    DatabaseFacade Database {  get; }   

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
