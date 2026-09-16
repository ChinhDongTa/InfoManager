namespace InfoManager.Application.Features.FamilyMembers.Commands;

public record CreateFamilyMemberCommand : IRequest<Result<string>>
{
    public required string FullName { get; init; }
    public string? FamilyRelationId { get; init; }
    public DateOnly BirthDate { get; init; }
    public DateOnly? DeathDate { get; init; }
    public Gender Gender { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Note { get; init; }
}

public class CreateFamilyMemberCommandHandler : BaseCreateCommandHandler<CreateFamilyMemberCommand, FamilyMember>
{
    public CreateFamilyMemberCommandHandler(IApplicationDbContext context,
                                            IValidator<CreateFamilyMemberCommand> validator,
                                            ILogger<CreateFamilyMemberCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task AddEntityAsync(FamilyMember entity, CancellationToken cancellationToken)
    {
        await Context.FamilyMembers.AddAsync(entity, cancellationToken);
    }

    protected override async Task<FamilyMember> CreateEntity(CreateFamilyMemberCommand request)
    {
        return new FamilyMember
        {
            FullName = request.FullName.Trim(),
            FamilyRelationId = request.FamilyRelationId,
            BirthDate = request.BirthDate,
            DeathDate = request.DeathDate,
            Gender = request.Gender,
            Email = request.Email?.Trim(),
            PhoneNumber = request.PhoneNumber?.Trim(),
            Note = request.Note?.Trim()
        };
    }
}

public class CreateFamilyMemberCommandValidator : AbstractValidator<CreateFamilyMemberCommand>
{
    public CreateFamilyMemberCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("FullName"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("FullName", 200));

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage(ErrorHelpers.GetErrorInvalid("Email"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Email", 200))
            .When(x => !string.IsNullOrEmpty(x.Email));
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?\d{10,15}$").WithMessage(ErrorHelpers.GetErrorInvalid("PhoneNumber"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("PhoneNumber", 50))
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));
    }
}