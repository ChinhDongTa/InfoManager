namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record DeleteEmployeeContractCommand(string Id) : IRequest<Result>;

public class DeleteEmployeeContractCommandHandler : BaseDeleteCommandHandler<DeleteEmployeeContractCommand, EmployeeContract>
{
    public DeleteEmployeeContractCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteEmployeeContractCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<EmployeeContract?> GetEntityAsync(DeleteEmployeeContractCommand request, CancellationToken ct)
        => await Context.EmployeeContracts.FindAsync([request.Id], ct);
}