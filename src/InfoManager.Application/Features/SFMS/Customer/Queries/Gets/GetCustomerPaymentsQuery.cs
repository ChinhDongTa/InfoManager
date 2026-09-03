namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

public record GetCustomerPaymentsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<CustomerPaymentSummaryDto>>>;
public class GetCustomerPaymentsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCustomerPaymentsQuery, Result<PaginatedList<CustomerPaymentSummaryDto>>>
{
    public async Task<Result<PaginatedList<CustomerPaymentSummaryDto>>> Handle(GetCustomerPaymentsQuery request, CancellationToken cancellationToken)
    {
        var paged = await context.CustomerPayments
            .ApplySorting()
            .ToCustomerPaymentSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<CustomerPaymentSummaryDto>>.Success(paged);
    }
}