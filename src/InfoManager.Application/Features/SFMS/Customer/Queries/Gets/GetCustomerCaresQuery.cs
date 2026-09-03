namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

public record GetCustomerCaresQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<CustomerCareSummaryDto>>>;
public class GetCustomerCaresQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCustomerCaresQuery, Result<PaginatedList<CustomerCareSummaryDto>>>
{
    public async Task<Result<PaginatedList<CustomerCareSummaryDto>>> Handle(GetCustomerCaresQuery request, CancellationToken cancellationToken)
    {
        var paged = await context.CustomerCares
            .ApplySorting()
            .ToCustomerCareSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<CustomerCareSummaryDto>>.Success(paged);
    }
}
