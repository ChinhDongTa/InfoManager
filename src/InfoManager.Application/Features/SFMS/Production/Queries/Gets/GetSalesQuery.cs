namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record GetSalesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<SaleSummaryDto>>>;

public class GetSalesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSalesQuery, Result<PaginatedList<SaleSummaryDto>>>
{
    public async Task<Result<PaginatedList<SaleSummaryDto>>> Handle(GetSalesQuery request, CancellationToken ct)
    {
        var result = await context.Sales
            .ApplySorting()
            .ToSaleSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<SaleSummaryDto>>.Success(result);
    }
}