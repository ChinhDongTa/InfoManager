using InfoManager.Application.Common.Interfaces;
using InfoManager.Domain.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InfoManager.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor(IUser user, TimeProvider dateTime) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
                                                                          InterceptionResult<int> result,
                                                                          CancellationToken ct = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, ct);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State is EntityState.Added or EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                // Always use UTC now
                var utcNow = dateTime.GetUtcNow();
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = user.Id;
                    entry.Entity.Created = utcNow;
                }
                entry.Entity.LastModifiedBy = user.Id;
                entry.Entity.LastModified = utcNow;
            }
        }

        // Normalize all DateTimeOffset properties to UTC across all entities
        // This ensures PostgreSQL compatibility (only accepts UTC offset 0)
        foreach (var entry in context.ChangeTracker.Entries())
        {
            foreach (var prop in entry.Properties)
            {
                var t = prop.Metadata.ClrType;
                if (t == typeof(DateTimeOffset))
                {
                    if (prop.CurrentValue is DateTimeOffset dto && dto.Offset != TimeSpan.Zero)
                    {
                        prop.CurrentValue = dto.ToUniversalTime();
                    }
                }
                else if (t == typeof(DateTimeOffset?))
                {
                    if (prop.CurrentValue is DateTimeOffset dtoNullable && dtoNullable.Offset != TimeSpan.Zero)
                    {
                        prop.CurrentValue = dtoNullable.ToUniversalTime();
                    }
                }
            }
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}