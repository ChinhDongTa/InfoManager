namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record DeletePayrollCommand(string Id) : IRequest<Result>;

public class DeletePayrollCommandHandler : BaseDeleteCommandHandler<DeletePayrollCommand, Payroll>
{
    public DeletePayrollCommandHandler(IApplicationDbContext context,
                                     ILogger<DeletePayrollCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Payroll?> GetEntityAsync(DeletePayrollCommand request, CancellationToken ct)
        => await Context.Payrolls.FindAsync([request.Id], ct);
}