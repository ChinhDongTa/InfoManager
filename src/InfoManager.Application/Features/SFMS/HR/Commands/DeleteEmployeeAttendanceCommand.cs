namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record DeleteEmployeeAttendanceCommand(string Id) : IRequest<Result>;

public class DeleteEmployeeAttendanceCommandHandler : BaseDeleteCommandHandler<DeleteEmployeeAttendanceCommand, EmployeeAttendance>
{
    public DeleteEmployeeAttendanceCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteEmployeeAttendanceCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<EmployeeAttendance?> GetEntityAsync(DeleteEmployeeAttendanceCommand request, CancellationToken ct)
        => await Context.EmployeeAttendances.FindAsync([request.Id], ct);
}