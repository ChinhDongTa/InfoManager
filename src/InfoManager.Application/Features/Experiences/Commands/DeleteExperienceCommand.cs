namespace InfoManager.Application.Features.Experiences.Commands;

public record DeleteExperienceCommand(string Id) : IRequest<Result>;

public class DeleteExperienceCommandHandler : BaseDeleteCommandHandler<DeleteExperienceCommand, Experience>
{
    public DeleteExperienceCommandHandler(IApplicationDbContext context,
                                           ILogger<DeleteExperienceCommandHandler> logger)
        : base(context, logger)
    {
    }

    protected override async Task<Experience?> GetEntityAsync(DeleteExperienceCommand request, CancellationToken ct)
    {
        return await Context.Experiences.FindAsync([request.Id], ct);
    }
}