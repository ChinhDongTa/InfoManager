// CÁCH ÁPDỤNG BASE HANDLERS CHO CÁC ENTITY KHÁC
// =============================================

/*
PATTERN UNTUK UPDATE COMMAND
=============================

Ví dụ: UpdateExperienceCommand

1. COMMAND (Record)
2. HANDLER (kế thừa BaseUpdateCommandHandler<TCommand, TEntity>)
3. VALIDATOR (kế thừa AbstractValidator<TCommand> và IUpdateCommandValidator<TCommand>)
*/

// ============ EXAMPLE 1: Experience Entity Update ============

namespace InfoManager.Application.Features.Experiences.Commands;

// Step 1: Define Command
public record UpdateExperienceCommand : IRequest<Result>
{
	public required string Id { get; init; }
	public string? Title { get; init; }
	public string? Description { get; init; }
	public DateOnly? ExperienceDate { get; init; }
}

// Step 2: Create Handler by inheriting BaseUpdateCommandHandler
public class UpdateExperienceCommandHandler(
	IApplicationDbContext context,
	IValidator<UpdateExperienceCommand> validator,
	ILogger<UpdateExperienceCommandHandler> logger)
	: BaseUpdateCommandHandler<UpdateExperienceCommand, Experience>
{
	public UpdateExperienceCommandHandler(
		IApplicationDbContext context,
		IValidator<UpdateExperienceCommand> validator,
		ILogger<UpdateExperienceCommandHandler> logger)
		: base(context, validator, logger)
	{
	}

	// Override GetEntityAsync to fetch the entity
	protected override async Task<Experience?> GetEntityAsync(UpdateExperienceCommand request, CancellationToken ct)
	{
		return await Context.Experiences.FindAsync([request.Id], ct);
	}

	// Override UpdateEntityProperties to map command properties to entity
	protected override void UpdateEntityProperties(Experience entity, UpdateExperienceCommand request)
	{
		entity.Title = request.Title ?? entity.Title;
		entity.Description = request.Description ?? entity.Description;
		entity.ExperienceDate = request.ExperienceDate ?? entity.ExperienceDate;
	}
}

// Step 3: Create Validator implementing IUpdateCommandValidator
public class UpdateExperienceCommandValidator : AbstractValidator<UpdateExperienceCommand>, IUpdateCommandValidator<UpdateExperienceCommand>
{
	public UpdateExperienceCommandValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));

		RuleFor(x => x)
			.Must(x => HasAtLeastOneFieldToUpdate(x))
			.WithMessage("At least one field (Title, Description, or ExperienceDate) must be provided for update.");

		RuleFor(x => x.Title)
			.MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Title", 200))
			.When(x => !string.IsNullOrEmpty(x.Title));

		RuleFor(x => x.Description)
			.MaximumLength(5000).WithMessage(ErrorHelpers.GetErrorMaxLength("Description", 5000))
			.When(x => !string.IsNullOrEmpty(x.Description));
	}

	public bool HasAtLeastOneFieldToUpdate(UpdateExperienceCommand command)
	{
		return !string.IsNullOrEmpty(command.Title) ||
			   !string.IsNullOrEmpty(command.Description) ||
			   command.ExperienceDate.HasValue;
	}
}

// ============ EXAMPLE 2: Delete Command ============

public record DeleteExperienceCommand(string Id) : IRequest<Result>;

public class DeleteExperienceCommandHandler(
	IApplicationDbContext context,
	ILogger<DeleteExperienceCommandHandler> logger)
	: BaseDeleteCommandHandler<DeleteExperienceCommand, Experience>
{
	public DeleteExperienceCommandHandler(
		IApplicationDbContext context,
		ILogger<DeleteExperienceCommandHandler> logger)
		: base(context, logger)
	{
	}

	protected override async Task<Experience?> GetEntityAsync(DeleteExperienceCommand request, CancellationToken ct)
	{
		return await Context.Experiences.FindAsync([request.Id], ct);
	}
}

// ============ EXAMPLE 3: Create Command ============

public record CreateExperienceCommand : IRequest<Result<string>>
{
	public required string Title { get; init; }
	public string? Description { get; init; }
	public required DateOnly ExperienceDate { get; init; }
}

public class CreateExperienceCommandHandler(
	IApplicationDbContext context,
	IValidator<CreateExperienceCommand> validator,
	ILogger<CreateExperienceCommandHandler> logger)
	: BaseCreateCommandHandler<CreateExperienceCommand, Experience>
{
	public CreateExperienceCommandHandler(
		IApplicationDbContext context,
		IValidator<CreateExperienceCommand> validator,
		ILogger<CreateExperienceCommandHandler> logger)
		: base(context, validator, logger)
	{
	}

	protected override Experience CreateEntity(CreateExperienceCommand request)
	{
		return new Experience
		{
			Title = request.Title,
			Description = request.Description,
			ExperienceDate = request.ExperienceDate
		};
	}
}

public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
{
	public CreateExperienceCommandValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Title"))
			.MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Title", 200));

		RuleFor(x => x.Description)
			.MaximumLength(5000).WithMessage(ErrorHelpers.GetErrorMaxLength("Description", 5000));

		RuleFor(x => x.ExperienceDate)
			.NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("ExperienceDate"))
			.LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
			.WithMessage("Experience date cannot be in the future.");
	}
}

/*
AUDIT FIELDS HANDLING
=====================

⚠️ IMPORTANT: Do NOT manually set Created, CreatedBy, LastModified, LastModifiedBy fields!

The AuditableEntityInterceptor handles this automatically:
- When entity is ADDED: Sets Created and CreatedBy (gets user ID from IUser service)
- When entity is MODIFIED: Sets LastModified and LastModifiedBy (gets user ID from IUser service)

The IUser service gets the current user ID from HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)

✅ DO:
  entity.Title = request.Title;
  await context.SaveChangesAsync();

❌ DON'T:
  entity.Created = DateTime.UtcNow;
  entity.CreatedBy = userId;
  entity.LastModified = DateTime.UtcNow;
  entity.LastModifiedBy = userId;


SOFT DELETE PATTERN
===================

If your entity inherits from BaseAuditableEntity, it has an IsDeleted property.
You have two options:

Option 1: Hard Delete (Current Implementation)
- Simply call context.Set<TEntity>().Remove(entity);
- Entity is deleted from database

Option 2: Soft Delete (Optional)
- Instead of removing, set entity.IsDeleted = true;
- Entity remains in database but is marked as deleted
- Remember to filter IsDeleted == false in queries

Example soft delete:
  protected override async Task DeleteAsync(DeleteExperienceCommand request, CancellationToken ct)
  {
	  var entity = await GetEntity(request, ct);
	  entity.IsDeleted = true;
	  await Context.SaveChangesAsync(ct);
  }


KEY ADVANTAGES OF THIS PATTERN
==============================

1. DRY (Don't Repeat Yourself)
   - Reusable base handlers reduce code duplication
   - Consistent error handling across all commands

2. Automatic Audit Trail
   - AuditableEntityInterceptor automatically tracks who made changes and when
   - No need to manually set audit fields

3. Consistent Validation
   - IUpdateCommandValidator ensures all updates have at least one field
   - Prevents no-op database calls

4. Better Performance
   - Validation happens before database queries
   - Interceptor handles audit field updates in one place

5. Easy to Extend
   - Override methods to customize behavior for specific entities
   - Add DbUpdateException handling for business rule violations


TESTING TIPS
============

1. Mock IApplicationDbContext
2. Mock IValidator<TCommand>
3. Mock ILogger<THandler>
4. Test GetEntityAsync returns null -> NotFound result
5. Test UpdateEntityProperties correctly maps fields
6. Test exceptions are caught and logged
7. Test audit fields are NOT set in handler (they're set by interceptor)

Example Test:
  [Fact]
  public async Task Handle_WhenCategoryExists_UpdatesEntity()
  {
	  // Arrange
	  var command = new UpdateCategoryCommand { Id = "1", Name = "New Name" };
	  var category = new Category { Id = "1", Name = "Old Name" };

	  var mockContext = new Mock<IApplicationDbContext>();
	  mockContext.Setup(c => c.Categories.FindAsync(It.IsAny<object[]>(), It.IsAny<CancellationToken>()))
		  .ReturnsAsync(category);

	  var handler = new UpdateCategoryCommandHandler(mockContext.Object, validator, logger);

	  // Act
	  var result = await handler.Handle(command, CancellationToken.None);

	  // Assert
	  Assert.True(result.IsSuccess);
	  Assert.Equal("New Name", category.Name);
  }


COMMON MISTAKES TO AVOID
=========================

❌ Setting audit fields manually in handler
❌ Throwing exceptions instead of returning Result.Failure
❌ Not validating command before database query
❌ Using First() on errors - could throw if no errors (though this is checked)
❌ Not logging entity ID for debugging
❌ Catching all exceptions as generic error message without specific handling
✅ Use try-catch for DbUpdateException separately from general exceptions
