namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;
using Domain.Entities.SFMS.Customers;
public record SearchCustomersQuery(string? Term,
    CustomerType? CustomerType,
    decimal? MinCreditLimit,
    decimal? MaxCreditLimit,
    CustomerStatus? Status,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<CustomerSummaryDto>>>;
public class SearchCustomersQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchCustomersQuery, Result<PaginatedList<CustomerSummaryDto>>>
{
    public async Task<Result<PaginatedList<CustomerSummaryDto>>> Handle(SearchCustomersQuery request, CancellationToken cancellationToken)
    {
        var query = BuildSearchQuery( request);
        var paged= await query.ApplySorting()
            .ToCustomerSummaryDto()
            .PaginatedListAsync(request.PageNumber,request.PageSize,cancellationToken);
        return Result<PaginatedList<CustomerSummaryDto>>.Success(paged);
    }

    private IQueryable<Customer> BuildSearchQuery( SearchCustomersQuery request)
    {
        IQueryable<Customer> query = context.Customers.AsQueryable();
        if (!string.IsNullOrEmpty(request.Term))
        {
            var key = $"%{request.Term.Trim()}%";
            query = query.Where(c => (c.CustomerCode != null && EF.Functions.ILike(c.CustomerCode, key))
                                                  ||(EF.Functions.ILike(c.Name,key))
                                                  || (c.Phone != null && EF.Functions.ILike(c.Phone, key))
                                                  || (c.Email != null && EF.Functions.ILike(c.Email, key))
                                                  || (c.Address != null && EF.Functions.ILike(c.Address, key))
                                                  || (c.TaxCode != null && EF.Functions.ILike(c.TaxCode, key))
            );
        }
        if (request.CustomerType.HasValue)
            query = query.Where(c => c.CustomerType == request.CustomerType);
        if (request.Status.HasValue)
            query = query.Where(c => c.Status == request.Status);
        if (request.MinCreditLimit.HasValue)
            query = query.Where(c => c.CreditLimit >= request.MinCreditLimit);
        if (request.MaxCreditLimit.HasValue)
            query = query.Where(c => c.CreditLimit <= request.MaxCreditLimit);
        return query;
    }
}