namespace InfoManager.Application.Features.SocialAccounts.Commands;

public record CreateSocialAccountCommand : IRequest<Result<string>>
{
    public required string UserId { get; init; }
    public required string Provider { get; init; }
    public required string ProviderAccountId { get; init; }
    public string? DisplayName { get; init; }
    public bool IsPrimary { get; init; }
    public string? HomepageUrl { get; init; }
}
public class CreateSocialAccountCommandHandler : BaseCreateCommandHandler<CreateSocialAccountCommand, SocialAccount>
{
    public CreateSocialAccountCommandHandler(IApplicationDbContext context,
                                             IValidator<CreateSocialAccountCommand> validator,
                                             ILogger<CreateSocialAccountCommandHandler> logger) : base(context, validator, logger)
    {
    }
    protected override async Task<SocialAccount> CreateEntity(CreateSocialAccountCommand request)
    {
        return new SocialAccount
        {
            UserId = request.UserId.Trim(),
            Provider = request.Provider.Trim(),
            ProviderAccountId = request.ProviderAccountId.Trim(),
            DisplayName = request.DisplayName?.Trim(),
            IsPrimary = request.IsPrimary,
            HomepageUrl = request.HomepageUrl?.Trim()
        };
    }
    protected override async Task AddEntityAsync(SocialAccount entity, CancellationToken cancellationToken)
    {
        await Context.SocialAccounts.AddAsync(entity, cancellationToken);
    }
}
public class CreateSocialAccountCommandValidator : AbstractValidator<CreateSocialAccountCommand>
{
    public CreateSocialAccountCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("UserId"));
        RuleFor(x => x.Provider)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Provider"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Provider", 50));
        RuleFor(x => x.ProviderAccountId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("ProviderAccountId"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("ProviderAccountId", 100));
        RuleFor(x => x.DisplayName)
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("DisplayName", 200))
            .When(x => !string.IsNullOrEmpty(x.DisplayName));
        RuleFor(x => x.HomepageUrl)
            .MaximumLength(300).WithMessage(ErrorHelpers.GetErrorMaxLength("HomepageUrl", 300))
            .When(x => !string.IsNullOrEmpty(x.HomepageUrl));
    }
}
