namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record DeleteWorkShiftCommand(string Id) : IRequest<Result>;

public class DeleteWorkShiftCommandHandler : BaseDeleteCommandHandler<DeleteWorkShiftCommand, WorkShift>
{
    public DeleteWorkShiftCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteWorkShiftCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<WorkShift?> GetEntityAsync(DeleteWorkShiftCommand request, CancellationToken ct)
        => await Context.WorkShifts.FindAsync([request.Id], ct);
}