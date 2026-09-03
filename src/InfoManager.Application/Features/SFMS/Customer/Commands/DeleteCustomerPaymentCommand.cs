namespace InfoManager.Application.Features.SFMS.Customer.Commands;

public record DeleteCustomerPaymentCommand(string Id) : IRequest<Result>;
public class DeleteCustomerPaymentCommandHandler : BaseDeleteCommandHandler<DeleteCustomerPaymentCommand,CustomerPayment>
{
    public DeleteCustomerPaymentCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteCustomerPaymentCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<CustomerPayment?> GetEntityAsync(DeleteCustomerPaymentCommand request, CancellationToken cancellationToken)
        => await Context.CustomerPayments.FindAsync([request.Id], cancellationToken);
}