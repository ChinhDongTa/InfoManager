using InfoManager.Domain.Common;

namespace InfoManager.Application.Common.Handlers;

/// <summary>
/// Generic base handler for Create commands.
/// Provides common logic for creating entities, including validation, database insertion, and error handling.
///
/// Note: Since IApplicationDbContext is not generic (doesn't expose Set<T>()),
/// you must override AddEntityAsync to handle the actual insertion using the specific DbSet property.
/// </summary>
/// <typeparam name="TCommand">The create command type that implements IRequest<Result<string>></typeparam>
/// <typeparam name="TEntity">The entity type to create (must be BaseAuditableEntity)</typeparam>
public abstract class BaseCreateCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, Result<string>>
    where TCommand : class, IRequest<Result<string>>
    where TEntity : BaseEntity
{
    protected readonly IApplicationDbContext Context;
    protected readonly IValidator<TCommand> Validator;
    protected readonly ILogger Logger;

    protected BaseCreateCommandHandler(IApplicationDbContext context, IValidator<TCommand> validator, ILogger logger)
    {
        Context = context;
        Validator = validator;
        Logger = logger;
    }

    public virtual async Task<Result<string>> Handle(TCommand request, CancellationToken ct)
    {
        try
        {
            // 1. Validate command
            var validationResult = await Validator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                return Result<string>.Error(validationResult.Errors.Select(e => e.ErrorMessage).ToArray());
            }

            // 2. Create entity
            var entity = await CreateEntity(request);

            // 3. Add to context (call abstract method for specific addition logic)
            await AddEntityAsync(entity, ct);

            // 4. Save changes (AuditableEntityInterceptor will handle audit fields)
            await Context.SaveChangesAsync(ct);

            return Result<string>.Created(entity.Id);
        }
        catch (DbUpdateException ex)
        {
            Logger.LogError(ex, "Database error occurred while creating {EntityName}", typeof(TEntity).Name);
            return Result<string>.Error($"An error occurred while creating {typeof(TEntity).Name}.");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error occurred while creating {EntityName}", typeof(TEntity).Name);
            return Result<string>.Error($"An error occurred while creating {typeof(TEntity).Name}.");
        }
    }

    /// <summary>
    /// Creates a new entity instance based on the command.
    /// Override this method to customize entity creation and property mapping.
    /// </summary>
    protected abstract Task<TEntity> CreateEntity(TCommand request);

    /// <summary>
    /// Adds the entity to the database context.
    /// Override this method to use the specific DbSet property from IApplicationDbContext.
    ///
    /// Example for Category:
    ///   protected override async Task AddEntityAsync(Category entity, CancellationToken ct)
    ///   {
    ///       Context.Categories.Add(entity);
    ///       await Task.CompletedTask;
    ///   }
    /// </summary>
    protected abstract Task AddEntityAsync(TEntity entity, CancellationToken ct);
}