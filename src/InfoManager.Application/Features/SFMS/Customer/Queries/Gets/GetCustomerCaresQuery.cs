namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

public record GetCustomerCaresQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<CustomerCareSummaryDto>>>;

public class GetCustomerCaresQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCustomerCaresQuery, Result<PaginatedList<CustomerCareSummaryDto>>>
{
    public async Task<Result<PaginatedList<CustomerCareSummaryDto>>> Handle(GetCustomerCaresQuery request, CancellationToken ct)
    {
        var paged = await context.CustomerCares
            .ApplySorting()
            .ToCustomerCareSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<CustomerCareSummaryDto>>.Success(paged);
    }
}