using InfoManager.Domain.Common;


namespace InfoManager.Application.Common.Handlers;

/// <summary>
/// Generic base handler for Update commands.
/// Provides common logic for updating entities, including validation, database updates, and error handling.
/// </summary>
/// <typeparam name="TCommand">The update command type that implements IRequest<Result></typeparam>
/// <typeparam name="TEntity">The entity type to update (must be BaseAuditableEntity)</typeparam>
public abstract class BaseUpdateCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, Result>
    where TCommand : class, IRequest<Result>
    where TEntity : BaseEntity
{
    protected readonly IApplicationDbContext Context;
    protected readonly IValidator<TCommand> Validator;
    protected readonly ILogger Logger;

    protected BaseUpdateCommandHandler(IApplicationDbContext context, IValidator<TCommand> validator, ILogger logger)
    {
        Context = context;
        Validator = validator;
        Logger = logger;
    }

    public virtual async Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // 1. Validate command
            var validationResult = await Validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new Result(ResultStatus.Error, validationResult.Errors.Select(e => e.ErrorMessage).ToArray());
            }

            // 2. Find entity
            var entity = await GetEntityAsync(request, cancellationToken);
            if (entity == null)
            {
                var entityName = typeof(TEntity).Name;
                var entityId = GetEntityId(request);
                return Result.NotFound(entityName, entityId);
            }

            // 3. Update entity properties
            await UpdateEntityProperties(entity, request);

            // 4. Save changes (AuditableEntityInterceptor will handle audit fields)
            await Context.SaveChangesAsync(cancellationToken);

            return Result.Success(ResultStatus.NoContent);
        }
        catch (DbUpdateException ex)
        {
            Logger.LogError(ex, "Database error occurred while updating {EntityName}", typeof(TEntity).Name);
            return new Result(ResultStatus.Error, [$"An error occurred while updating {typeof(TEntity).Name}."]);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error occurred while updating {EntityName} with Id: {Id}", typeof(TEntity).Name, GetEntityId(request));
            return new Result(ResultStatus.Error, [$"An error occurred while updating {typeof(TEntity).Name}."]);
        }
    }

    /// <summary>
    /// Retrieves the entity from the database based on the command.
    /// Override this method to customize entity retrieval logic.
    /// </summary>
    protected abstract Task<TEntity?> GetEntityAsync(TCommand request, CancellationToken cancellationToken);

    /// <summary>
    /// Updates the entity properties based on the command.
    /// Override this method to customize property mapping from command to entity.
    /// </summary>
    protected abstract Task UpdateEntityProperties(TEntity entity, TCommand request);

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
