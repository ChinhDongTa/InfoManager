namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

public record SearchCustomerPaymentsQuery(string? Term,
                                          DateTimeOffset? StartPaymentDate,
                                          DateTimeOffset? EndPaymentDate,
                                          int PageNumber,
                                          int PageSize) : IRequest<Result<PaginatedList<CustomerPaymentSummaryDto>>>;
public class SearchCustomerPaymentsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchCustomerPaymentsQuery, Result<PaginatedList<CustomerPaymentSummaryDto>>>
{
    public async Task<Result<PaginatedList<CustomerPaymentSummaryDto>>> Handle(SearchCustomerPaymentsQuery request, CancellationToken cancellationToken)
    {
        var query = BuildSearchQuery(context.CustomerPayments.AsQueryable(), request.Term,request.StartPaymentDate,request.EndPaymentDate);
        var paged = await query.ApplySorting()
            .ToCustomerPaymentSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<CustomerPaymentSummaryDto>>.Success(paged);
    }

    private static IQueryable<CustomerPayment> BuildSearchQuery(IQueryable<CustomerPayment> customers,
                                                                string? term,
                                                                DateTimeOffset? StartPaymentDate,
                                                                DateTimeOffset? EndPaymentDate)
    {
        if (!string.IsNullOrEmpty(term))
        {
            var key = $"%{term.Trim()}%";
            customers = customers.Where(c => (c.PaymentMethod != null && EF.Functions.ILike(c.PaymentMethod, key))
                                                  || (c.ReferenceNumber != null && EF.Functions.ILike(c.ReferenceNumber, key))
            );
        }
        if(StartPaymentDate.HasValue)
        {
            customers = customers.Where(c=>c.PaymentDate>=StartPaymentDate);
        }
        if (EndPaymentDate.HasValue)
        {
            customers = customers.Where(c => c.PaymentDate <= EndPaymentDate);
        }
        return customers;
    }
}