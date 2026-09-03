namespace InfoManager.Application.Features.SocialAccounts.Commands;

public record DeleteSocialAccountCommand(string Id) : IRequest<Result>;
public class DeleteSocialAccountCommandHandler : BaseDeleteCommandHandler<DeleteSocialAccountCommand, SocialAccount>
{
    public DeleteSocialAccountCommandHandler(IApplicationDbContext context,
                                              ILogger<DeleteSocialAccountCommandHandler> logger) : base(context, logger)
    {
    }
    protected override async Task<SocialAccount?> GetEntityAsync(DeleteSocialAccountCommand request, CancellationToken cancellationToken)
    {
        return await Context.SocialAccounts.FindAsync([request.Id], cancellationToken);
    }
    
}