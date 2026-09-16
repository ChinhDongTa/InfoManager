namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

public record GetCustomersQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<CustomerSummaryDto>>>;

public class GetCustomersQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCustomersQuery, Result<PaginatedList<CustomerSummaryDto>>>
{
    public async Task<Result<PaginatedList<CustomerSummaryDto>>> Handle(GetCustomersQuery request, CancellationToken ct)
    {
        var paged = await context.Customers
            .ApplySorting()
            .ToCustomerSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<CustomerSummaryDto>>.Success(paged);
    }
}