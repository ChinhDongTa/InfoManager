
namespace InfoManager.Application.Features.SFMS.HR.Commands;
public record DeleteDepartmentCommand(string Id) : IRequest<Result>;
public class DeleteDepartmentCommandHandler : BaseDeleteCommandHandler<DeleteDepartmentCommand, Department>
{
    public DeleteDepartmentCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteDepartmentCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Department?> GetEntityAsync(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        => await Context.Departments.FindAsync([request.Id], cancellationToken);
}