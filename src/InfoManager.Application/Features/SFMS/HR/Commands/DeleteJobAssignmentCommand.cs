namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record DeleteJobAssignmentCommand(string Id) : IRequest<Result>;
public class DeleteJobAssignmentCommandHandler : BaseDeleteCommandHandler<DeleteJobAssignmentCommand, JobAssignment>
{
    public DeleteJobAssignmentCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteJobAssignmentCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<JobAssignment?> GetEntityAsync(DeleteJobAssignmentCommand request, CancellationToken cancellationToken)
        => await Context.JobAssignments.FindAsync([request.Id], cancellationToken);
}