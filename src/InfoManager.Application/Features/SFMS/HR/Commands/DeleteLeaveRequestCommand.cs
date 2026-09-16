namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record DeleteLeaveRequestCommand(string Id) : IRequest<Result>;

public class DeleteLeaveRequestCommandHandler : BaseDeleteCommandHandler<DeleteLeaveRequestCommand, LeaveRequest>
{
    public DeleteLeaveRequestCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteLeaveRequestCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<LeaveRequest?> GetEntityAsync(DeleteLeaveRequestCommand request, CancellationToken ct)
        => await Context.LeaveRequests.FindAsync([request.Id], ct);
}