namespace InfoManager.Application.Features.SocialAccounts.Commands;

public record UpdateSocialAccountCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? UserId { get; init; }
    public string? Provider { get; init; }
    public string? ProviderAccountId { get; init; }
    public string? DisplayName { get; init; }
    public bool? IsPrimary { get; init; }
    public string? HomepageUrl { get; init; }
}
public class UpdateSocialAccountCommandHandler : BaseUpdateCommandHandler<UpdateSocialAccountCommand, SocialAccount>
{
    public UpdateSocialAccountCommandHandler(IApplicationDbContext context,
                                             IValidator<UpdateSocialAccountCommand> validator,
                                             ILogger<UpdateSocialAccountCommandHandler> logger) : base(context, validator, logger)
    {
    }
    protected override async Task<SocialAccount?> GetEntityAsync(UpdateSocialAccountCommand request, CancellationToken cancellationToken)
    {
        return await Context.SocialAccounts.FindAsync([request.Id], cancellationToken);
    }
    protected override async Task UpdateEntityProperties(SocialAccount entity, UpdateSocialAccountCommand request)
    {
        if (request.UserId.HasValueAndIsDifferentFrom(entity.UserId))
            entity.UserId = request.UserId!.Trim();
        if (request.Provider.HasValueAndIsDifferentFrom(entity.Provider))
            entity.Provider = request.Provider!.Trim();
        if (request.ProviderAccountId.HasValueAndIsDifferentFrom(entity.ProviderAccountId))
            entity.ProviderAccountId = request.ProviderAccountId!.Trim();
        if (request.DisplayName.IsDifferentFrom(entity.DisplayName))
            entity.DisplayName = request.DisplayName?.Trim();
        if (request.IsPrimary.HasValue && request.IsPrimary.Value != entity.IsPrimary)
            entity.IsPrimary = request.IsPrimary.Value;
        if (request.HomepageUrl.IsDifferentFrom(entity.HomepageUrl))
            entity.HomepageUrl = request.HomepageUrl?.Trim();
    }
}
public class UpdateSocialAccountCommandValidator : AbstractValidator<UpdateSocialAccountCommand>
{
    public UpdateSocialAccountCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));
        RuleFor(x => x.Provider)
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Provider", 50))
            .When(x => !string.IsNullOrEmpty(x.Provider));
        RuleFor(x => x.ProviderAccountId)
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("ProviderAccountId", 100))
            .When(x => !string.IsNullOrEmpty(x.ProviderAccountId));
        RuleFor(x => x.DisplayName)
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("DisplayName", 200))
            .When(x => !string.IsNullOrEmpty(x.DisplayName));
        RuleFor(x => x.HomepageUrl)
            .MaximumLength(300).WithMessage(ErrorHelpers.GetErrorMaxLength("HomepageUrl", 300))
            .When(x => !string.IsNullOrEmpty(x.HomepageUrl));
    }
}
