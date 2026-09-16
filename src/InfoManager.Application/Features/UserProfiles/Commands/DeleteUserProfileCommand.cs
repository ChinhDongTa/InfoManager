namespace InfoManager.Application.Features.UserProfiles.Commands;

public record DeleteUserProfileCommand(string Id) : IRequest<Result>;

public class DeleteUserProfileCommandHandler : BaseDeleteCommandHandler<DeleteUserProfileCommand, UserProfile>
{
    public DeleteUserProfileCommandHandler(IApplicationDbContext context,

                                           ILogger<DeleteUserProfileCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<UserProfile?> GetEntityAsync(DeleteUserProfileCommand request, CancellationToken ct)
    {
        return await Context.UserProfiles.FindAsync([request.Id], ct);
    }
}