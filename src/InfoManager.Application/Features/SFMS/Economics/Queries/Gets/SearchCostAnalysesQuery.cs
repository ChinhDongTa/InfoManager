namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record SearchCostAnalysesQuery(
    string? Term,
    string? FarmId,
    string? CropPlantingId,
    DateTimeOffset? StartAnalysisDate,
    DateTimeOffset? EndAnalysisDate,
    DateTimeOffset? StartFromDate,
    DateTimeOffset? EndToDate,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<CostAnalysisSummaryDto>>>;
public class SearchCostAnalysesQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchCostAnalysesQuery, Result<PaginatedList<CostAnalysisSummaryDto>>>
{
    public async Task<Result<PaginatedList<CostAnalysisSummaryDto>>> Handle(SearchCostAnalysesQuery request, CancellationToken cancellationToken)
    {
        var result = await context.CostAnalyses.BuildSearchQuery(request)
                                               .ApplySorting()
                                               .ToCostAnalysisSummaryDto()
                                               .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<CostAnalysisSummaryDto>>.Success(result);
    }
}