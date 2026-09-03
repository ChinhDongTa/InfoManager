namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

public record GetCustomerPaymentByIdQuery(string Id) : IRequest<Result<CustomerPaymentDto?>>;
public class GetCustomerPaymentByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCustomerPaymentByIdQuery, Result<CustomerPaymentDto?>>
{
    public async Task<Result<CustomerPaymentDto?>> Handle(GetCustomerPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        return await context.CustomerPayments.Where(x => x.Id == request.Id)
            .ToCustomerPaymentDto()
            .SingleOrNotFoundAsync(nameof(CustomerPayment), request.Id, cancellationToken);
    }
}