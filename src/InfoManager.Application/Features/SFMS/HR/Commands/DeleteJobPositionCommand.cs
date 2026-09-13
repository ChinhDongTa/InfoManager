namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record DeleteJobPositionCommand(string Id) : IRequest<Result>;
public class DeleteJobPositionCommandHandler : BaseDeleteCommandHandler<DeleteJobPositionCommand, JobPosition>
{
    public DeleteJobPositionCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteJobPositionCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<JobPosition?> GetEntityAsync(DeleteJobPositionCommand request, CancellationToken cancellationToken)
        => await Context.JobPositions.FindAsync([request.Id], cancellationToken);
}