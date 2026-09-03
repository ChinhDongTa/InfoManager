using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Application.Features.Categories.Commands;

public record UpdateCategoryCommand () : IRequest<Result>
{
    public required string Id { get; init; }
    public string? Name { get; init; }
    public string? Group { get; init; }
    public string? KeyName { get; init; }
}


public class UpdateCategoryCommandHandler : BaseUpdateCommandHandler<UpdateCategoryCommand, Category>
{
    public UpdateCategoryCommandHandler(IApplicationDbContext context,
                                        IValidator<UpdateCategoryCommand> updateValidator,
                                        ILogger<UpdateCategoryCommandHandler> logger)
        : base(context, updateValidator, logger)
    {
    }

    protected override async Task<Category?> GetEntityAsync(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await Context.Categories.FindAsync([request.Id], cancellationToken);
    }

    protected override async Task UpdateEntityProperties(Category entity, UpdateCategoryCommand request)
    {
        if (request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!;

        if (request.Group.IsDifferentFrom(entity.Group))
            entity.Group = request.Group;

        if (request.KeyName.IsDifferentFrom(entity.KeyName))
            entity.KeyName = request.KeyName;
    }
}
public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));

        RuleFor(x => x.Name)
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Name", 200))
            .When(x => !string.IsNullOrEmpty(x.Name));

        RuleFor(x => x.Group)
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Group", 50))
            .When(x => !string.IsNullOrEmpty(x.Group));

        RuleFor(x => x.KeyName)
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("KeyName", 50))
            .When(x => !string.IsNullOrEmpty(x.KeyName));
    }
}