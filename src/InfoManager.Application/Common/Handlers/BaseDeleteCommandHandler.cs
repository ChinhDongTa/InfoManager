using InfoManager.Domain.Common;

namespace InfoManager.Application.Common.Handlers;

/// <summary>
/// Generic base handler for Delete commands.
/// Provides common logic for deleting entities, including database deletion and error handling.
///
/// Note: Since IApplicationDbContext is not generic (doesn't expose Set<T>()),
/// you must override DeleteEntity to handle the actual deletion using the specific DbSet property.
/// </summary>
/// <typeparam name="TCommand">The delete command type that implements IRequest<Result></typeparam>
/// <typeparam name="TEntity">The entity type to delete (must be BaseAuditableEntity)</typeparam>
public abstract class BaseDeleteCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, Result>
    where TCommand : class, IRequest<Result>
    where TEntity : BaseEntity
{
    protected readonly IApplicationDbContext Context;
    protected readonly ILogger Logger;

    protected BaseDeleteCommandHandler(IApplicationDbContext context, ILogger logger)
    {
        Context = context;
        Logger = logger;
    }

    public virtual async Task<Result> Handle(TCommand request, CancellationToken ct)
    {
        try
        {
            // 1. Find entity
            var entity = await GetEntityAsync(request, ct);
            if (entity == null)
            {
                var entityName = typeof(TEntity).Name;
                var entityId = GetEntityId(request);
                return Result.NotFound(entityName, entityId);
            }

            // 2. Delete entity (call abstract method for specific deletion logic)
            //DeleteEntity(entity, ct);
            entity.IsDeleted = true; // Mark as deleted if using soft delete

            // 3. Save changes
            await Context.SaveChangesAsync(ct);

            return Result.Success(ResultStatus.NoContent);
        }
        catch (DbUpdateException ex)
        {
            Logger.LogError(ex, "Database error occurred while deleting {EntityName}", typeof(TEntity).Name);
            return Result.NotFound(typeof(TEntity).Name, GetEntityId(request));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error occurred while deleting {EntityName} with Id: {Id}", typeof(TEntity).Name, GetEntityId(request));
            return Result.NotFound(typeof(TEntity).Name, GetEntityId(request));
        }
    }

    /// <summary>
    /// Retrieves the entity from the database based on the command.
    /// Override this method to customize entity retrieval logic.
    /// </summary>
    protected abstract Task<TEntity?> GetEntityAsync(TCommand request, CancellationToken ct);

    /// <summary>
    /// Deletes the entity from the database.
    /// Override this method to use the specific DbSet property from IApplicationDbContext.
    ///
    /// Example for Category:
    ///   protected override void DeleteEntity(Category entity, CancellationToken ct)
    ///   {
    ///       Context.Categories.Remove(entity);
    ///   }
    /// </summary>
    //protected abstract void DeleteEntity(TEntity entity, CancellationToken ct);

    /// <summary>
    /// Gets the entity ID from the command for logging purposes.
    /// Override this method if the ID property has a different name.
    /// </summary>
    protected virtual string GetEntityId(TCommand request)
    {
        // Default implementation - try to get Id property from command
        var idProperty = typeof(TCommand).GetProperty("Id");
        return idProperty?.GetValue(request)?.ToString() ?? "Unknown";
    }
}