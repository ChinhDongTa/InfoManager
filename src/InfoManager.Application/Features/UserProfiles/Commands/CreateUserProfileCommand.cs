using InfoManager.Domain.Entities.Authentication;

namespace InfoManager.Application.Features.UserProfiles.Commands;

public record CreateUserProfileCommand : IRequest<Result<string>>
{
    public required string UserId { get; init; }
    public string? FamilyMemberId { get; init; }
    public string? FamilyId { get; init; }
    public string? Notes { get; init; } 
    public string? ImageUrl { get; init; }
}

public class CreateUserProfileCommandHandler : BaseCreateCommandHandler<CreateUserProfileCommand, UserProfile>
{
    public CreateUserProfileCommandHandler(IApplicationDbContext context,
                                            IValidator<CreateUserProfileCommand> validator,
                                            ILogger<CreateUserProfileCommandHandler> logger) : base(context, validator, logger)
    {
    }
    protected override async Task<UserProfile> CreateEntity(CreateUserProfileCommand request)
    {
        return new UserProfile
        {
            UserId = request.UserId.Trim(),
            FamilyMemberId = request.FamilyMemberId,
            FamilyId = request.FamilyId,
            Notes = request.Notes?.Trim(),
            ImageUrl = request.ImageUrl?.Trim()
        };
    }
    protected override async Task AddEntityAsync(UserProfile entity, CancellationToken cancellationToken)
    {
        await Context.UserProfiles.AddAsync(entity, cancellationToken);
    }
}
public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
{
    public CreateUserProfileCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("UserId"));
        RuleFor(x => x.Notes)
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Notes", 200))
            .When(x => !string.IsNullOrEmpty(x.Notes));
        RuleFor(x => x.ImageUrl)
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("ImageUrl", 500))
            .When(x => !string.IsNullOrEmpty(x.ImageUrl));
    }
}
