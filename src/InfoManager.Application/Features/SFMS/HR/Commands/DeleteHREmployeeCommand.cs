namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record DeleteHREmployeeCommand(string Id) : IRequest<Result>;

public class DeleteHREmployeeCommandHandler : BaseDeleteCommandHandler<DeleteHREmployeeCommand, HREmployee>
{
    public DeleteHREmployeeCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteHREmployeeCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<HREmployee?> GetEntityAsync(DeleteHREmployeeCommand request, CancellationToken ct)
        => await Context.HREmployees.FindAsync([request.Id], ct);
}