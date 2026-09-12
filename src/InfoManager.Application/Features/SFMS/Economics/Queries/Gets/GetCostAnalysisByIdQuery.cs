namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetCostAnalysisByIdQuery(string Id) : IRequest<Result<CostAnalysisDto>>;
//public class GetCostAnalysesQueryHandler (IApplicationDbContext context): IRequestHandler<GetCostAnalysesQuery, Result<PaginatedList<CostAnalysisSummaryDto>>>
//{
//    public async Task<Result<PaginatedList<CostAnalysisSummaryDto>>> Handle(GetCostAnalysesQuery request, CancellationToken cancellationToken)
//    {
        

//        return Result<PaginatedList<CostAnalysisSummaryDto>>.Success();
//    }
//}
