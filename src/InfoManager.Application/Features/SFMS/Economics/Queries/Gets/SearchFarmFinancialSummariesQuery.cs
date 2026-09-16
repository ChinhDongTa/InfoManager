namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record SearchFarmFinancialSummariesQuery(
    string? Term,
    string? FarmId,
    int? Year,
    int? Month,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<FarmFinancialSummarySummaryDto>>>;

public class SearchFarmFinancialSummariesQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchFarmFinancialSummariesQuery, Result<PaginatedList<FarmFinancialSummarySummaryDto>>>
{
    public async Task<Result<PaginatedList<FarmFinancialSummarySummaryDto>>> Handle(SearchFarmFinancialSummariesQuery request, CancellationToken ct)
    {
        var paged = await context.FarmFinancialSummaries.BuildSearchQuery(request)
            .ApplySorting()
            .ToFarmFinancialSummarySummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FarmFinancialSummarySummaryDto>>.Success(paged);
    }
}