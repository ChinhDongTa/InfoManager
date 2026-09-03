using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Application.Features.Families.Commands;

public record CreateFamilyCommand : IRequest<Result<string>>
{
    public required string Name { get; init; }
    public string? RepresentativeId { get; init; }
    public string? Address { get; init; }
    public string? Email { get; init; }
}
public class CreateFamilyCommandHandler : BaseCreateCommandHandler<CreateFamilyCommand, Family>
{
    public CreateFamilyCommandHandler(IApplicationDbContext context,
                                       IValidator<CreateFamilyCommand> validator,
                                       ILogger<CreateFamilyCommandHandler> logger)
        : base(context, validator, logger)
    {
    }
    protected override async Task AddEntityAsync(Family entity, CancellationToken cancellationToken)
    {
        await Context.Families.AddAsync(entity, cancellationToken);
    }
    protected override async Task<Family> CreateEntity(CreateFamilyCommand request)
    {
        return new Family
        {
            Name = request.Name.Trim(),
            RepresentativeId = request.RepresentativeId,
            Address = request.Address?.Trim(),
            Email = request.Email?.Trim()
        };
    }
}
public class CreateFamilyCommandValidator : AbstractValidator<CreateFamilyCommand>
{
    public CreateFamilyCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Name"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Name", 200));
        RuleFor(x => x.Address)
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Address", 500))
            .When(x => !string.IsNullOrEmpty(x.Address));
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage(ErrorHelpers.GetErrorInvalid("Email"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Email", 200))
            .When(x => !string.IsNullOrEmpty(x.Email));
    }
}
