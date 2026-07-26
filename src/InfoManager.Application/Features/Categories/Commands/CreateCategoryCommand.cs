namespace InfoManager.Application.Features.Categories.Commands;
public record CreateCategoryCommand : IRequest<Result<string>>
{
    public required string Name { get; init; }
    public string? Group { get; init; }
    public string? KeyName { get; init; }
}

public class CreateCategoryCommandHandler : BaseCreateCommandHandler<CreateCategoryCommand, Category>
{
    public CreateCategoryCommandHandler(IApplicationDbContext context,
                                        IValidator<CreateCategoryCommand> createValidator,
                                        ILogger<CreateCategoryCommandHandler> logger)
        : base(context, createValidator, logger)
    {
    }

    protected override Category CreateEntity(CreateCategoryCommand request)
    {
        return new Category
        {
            Name = request.Name.Trim(),
            Group = request.Group?.Trim(),
            KeyName = request.KeyName?.Trim()
        };
    }

    protected override async Task AddEntityAsync(Category entity, CancellationToken ct)
    {
        Context.Categories.Add(entity);
        await Task.CompletedTask;
    }
}

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Name"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Name", 200));

        RuleFor(x => x.Group)
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Group", 50));

        RuleFor(x => x.KeyName)
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("KeyName", 50));
    }
}