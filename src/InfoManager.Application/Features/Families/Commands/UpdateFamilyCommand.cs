namespace InfoManager.Application.Features.Families.Commands;

public record UpdateFamilyCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? Name { get; init; }
    public string? RepresentativeId { get; init; }
    public string? Address { get; init; }
    public string? Email { get; init; }
}

public class UpdateFamilyCommandHandler : BaseUpdateCommandHandler<UpdateFamilyCommand, Family>
{
    public UpdateFamilyCommandHandler(IApplicationDbContext context,
                                       IValidator<UpdateFamilyCommand> validator,
                                       ILogger<UpdateFamilyCommandHandler> logger)
        : base(context, validator, logger)
    {
    }

    protected override async Task<Family?> GetEntityAsync(UpdateFamilyCommand request, CancellationToken ct)
    {
        return await Context.Families.FindAsync([request.Id], ct);
    }

    protected override async Task UpdateEntityProperties(Family entity, UpdateFamilyCommand request)
    {
        if (request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!.Trim();
        if (request.RepresentativeId.IsDifferentFrom(entity.RepresentativeId))
            entity.RepresentativeId = request.RepresentativeId;
        if (request.Address.IsDifferentFrom(entity.Address))
            entity.Address = request.Address?.Trim();
        if (request.Email.IsDifferentFrom(entity.Email))
            entity.Email = request.Email?.Trim();
    }
}

public class UpdateFamilyCommandValidator : AbstractValidator<UpdateFamilyCommand>
{
    public UpdateFamilyCommandValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Name", 200))
            .When(x => !string.IsNullOrEmpty(x.Name));
        RuleFor(x => x.Address)
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Address", 500))
            .When(x => !string.IsNullOrEmpty(x.Address));
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage(ErrorHelpers.GetErrorInvalid("Email"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Email", 200))
            .When(x => !string.IsNullOrEmpty(x.Email));
    }
}