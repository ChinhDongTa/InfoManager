namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

public record GetCustomerByIdQuery(string Id) : IRequest<Result<CustomerDto?>>;
public class GetCustomerByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCustomerByIdQuery, Result<CustomerDto?>>
{
    public async Task<Result<CustomerDto?>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {

        var result = await context.Customers
            .Where(x => x.Id == request.Id)
            .ToCustomerDto()
            .SingleOrNotFoundAsync(nameof(Crop), request.Id, cancellationToken);
        return result;
    }
}