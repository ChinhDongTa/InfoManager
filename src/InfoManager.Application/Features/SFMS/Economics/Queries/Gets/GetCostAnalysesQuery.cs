namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetCostAnalysesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<CostAnalysisSummaryDto>>>;

public class GetCostAnalysesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCostAnalysesQuery, Result<PaginatedList<CostAnalysisSummaryDto>>>
{
    public async Task<Result<PaginatedList<CostAnalysisSummaryDto>>> Handle(GetCostAnalysesQuery request, CancellationToken ct)
    {
        var result = await context.CostAnalyses
           .ApplySorting()
           .ToCostAnalysisSummaryDto()
           .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<CostAnalysisSummaryDto>>.Success(result);
    }
}