namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetCostAnalysisByIdQuery(string Id) : IRequest<Result<CostAnalysisDto?>>;
public record GetCostAnalysisByIdQueryHandler(IApplicationDbContext Context) : IRequestHandler<GetCostAnalysisByIdQuery, Result<CostAnalysisDto?>>
{
    public async Task<Result<CostAnalysisDto?>> Handle(GetCostAnalysisByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await Context.CostAnalyses
           .Where(x => x.Id == request.Id)
           .ToCostAnalysisDto()
           .SingleOrNotFoundAsync(nameof(CostAnalysis), request.Id, cancellationToken);
        return result;
    }
}