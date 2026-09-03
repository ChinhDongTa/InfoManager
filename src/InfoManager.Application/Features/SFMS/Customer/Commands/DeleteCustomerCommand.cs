namespace InfoManager.Application.Features.SFMS.Customer.Commands;

public record DeleteCustomerCommand(string Id) : IRequest<Result>;
public class DeleteCustomerCommandHandler : BaseDeleteCommandHandler<DeleteCustomerCommand, Domain.Entities.SFMS.Customers.Customer>
{
    public DeleteCustomerCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteCustomerCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Domain.Entities.SFMS.Customers.Customer?> GetEntityAsync(DeleteCustomerCommand request, CancellationToken cancellationToken) 
        => await Context.Customers.FindAsync([request.Id], cancellationToken);
}