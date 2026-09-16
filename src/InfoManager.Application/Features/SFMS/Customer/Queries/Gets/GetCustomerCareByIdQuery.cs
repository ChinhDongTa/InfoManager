namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

public record GetCustomerCareByIdQuery(string Id) : IRequest<Result<CustomerCareDto?>>;

public class GetCustomerCareByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCustomerCareByIdQuery, Result<CustomerCareDto?>>
{
    public async Task<Result<CustomerCareDto?>> Handle(GetCustomerCareByIdQuery request, CancellationToken ct)
    {
        return await context.CustomerCares.Where(x => x.Id == request.Id)
            .ToCustomerCareDto()
            .SingleOrNotFoundAsync(nameof(CustomerCare), request.Id, ct);
    }
}