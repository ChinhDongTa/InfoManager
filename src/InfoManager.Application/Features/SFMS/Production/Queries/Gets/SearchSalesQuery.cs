namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record SearchSalesQuery(string? Term, string? ProductId, PaymentStatus? PaymentStatus, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<SaleSummaryDto>>>;

public class SearchSalesQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchSalesQuery, Result<PaginatedList<SaleSummaryDto>>>
{
    public async Task<Result<PaginatedList<SaleSummaryDto>>> Handle(
        SearchSalesQuery request, CancellationToken ct)
    {
        var query = Context.Sales.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToSaleSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<SaleSummaryDto>>.Success(paged);
    }
}