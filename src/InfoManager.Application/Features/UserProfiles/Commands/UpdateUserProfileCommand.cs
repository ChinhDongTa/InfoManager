namespace InfoManager.Application.Features.UserProfiles.Commands;

public record UpdateUserProfileCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? FamilyMemberId { get; init; }
    public string? FamilyId { get; init; }
    public string? Notes { get; init; }
    public string? ImageUrl { get; init; }
}

public class UpdateUserProfileCommandHandler : BaseUpdateCommandHandler<UpdateUserProfileCommand, UserProfile>
{
    public UpdateUserProfileCommandHandler(IApplicationDbContext context,
                                           IValidator<UpdateUserProfileCommand> validator,
                                           ILogger<UpdateUserProfileCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task<UserProfile?> GetEntityAsync(UpdateUserProfileCommand request, CancellationToken ct)
    {
        return await Context.UserProfiles.FindAsync([request.Id], ct);
    }

    protected override async Task UpdateEntityProperties(UserProfile entity, UpdateUserProfileCommand request)
    {
        if (request.FamilyMemberId.IsDifferentFrom(entity.FamilyMemberId))
            entity.FamilyMemberId = request.FamilyMemberId;
        if (request.FamilyId.IsDifferentFrom(entity.FamilyId))
            entity.FamilyId = request.FamilyId;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
        if (request.ImageUrl.IsDifferentFrom(entity.ImageUrl))
            entity.ImageUrl = request.ImageUrl;
    }
}

public class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
{
    public UpdateUserProfileCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));
        RuleFor(x => x.Notes)
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Notes", 200))
            .When(x => !string.IsNullOrEmpty(x.Notes));
        RuleFor(x => x.ImageUrl)
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("ImageUrl", 500))
            .When(x => !string.IsNullOrEmpty(x.ImageUrl));
    }
}