using BikeRentalSystem.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BikeRentalSystem.Server.Data.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        IReadOnlyCollection<EntityEntry<BaseAuditableEntity>> baseEntityEntries =
            context.ChangeTracker.Entries<BaseAuditableEntity>().ToList().AsReadOnly();

        if (baseEntityEntries == default) return;

        foreach (EntityEntry<BaseAuditableEntity> entry in baseEntityEntries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = 0;
                entry.Entity.CreatedAt = DateTime.Now;
            }

            if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted || entry.HasChangedOwnedEntities())
            {
                entry.Entity.ModifiedBy = 0;
                entry.Entity.ModifiedAt = DateTime.Now;
            }
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(reference =>
                                reference.TargetEntry != null &&
                                reference.TargetEntry.Metadata.IsOwned() &&
                                (reference.TargetEntry.State == EntityState.Added || reference.TargetEntry.State == EntityState.Modified));
}
