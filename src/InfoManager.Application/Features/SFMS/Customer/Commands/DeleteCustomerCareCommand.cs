namespace InfoManager.Application.Features.SFMS.Customer.Commands;

public record DeleteCustomerCareCommand(string Id) : IRequest<Result>;

public class DeleteCustomerCareCommandHandler : BaseDeleteCommandHandler<DeleteCustomerCareCommand, CustomerCare>
{
    public DeleteCustomerCareCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteCustomerCareCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<CustomerCare?> GetEntityAsync(DeleteCustomerCareCommand request, CancellationToken ct)
        => await Context.CustomerCares.FindAsync([request.Id], ct);
}