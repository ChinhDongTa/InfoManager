namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetCostAnalysesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<CostAnalysisSummaryDto>>>;
//public class GetCostAnalysesQueryHandler (IApplicationDbContext context): IRequestHandler<GetCostAnalysesQuery, Result<PaginatedList<CostAnalysisSummaryDto>>>
//{
//    public async Task<Result<PaginatedList<CostAnalysisSummaryDto>>> Handle(GetCostAnalysesQuery request, CancellationToken cancellationToken)
//    {
        

//        return Result<PaginatedList<CostAnalysisSummaryDto>>.Success();
//    }
//}
