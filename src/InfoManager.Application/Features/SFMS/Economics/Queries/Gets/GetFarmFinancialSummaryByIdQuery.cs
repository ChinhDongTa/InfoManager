namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetFarmFinancialSummaryByIdQuery(string Id) : IRequest<Result<FarmFinancialSummaryDto?>>;
public class GetFarmFinancialSummaryByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmFinancialSummaryByIdQuery, Result<FarmFinancialSummaryDto?>>
{
    public async Task<Result<FarmFinancialSummaryDto?>> Handle(GetFarmFinancialSummaryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.FarmFinancialSummaries
            .Where(x => x.Id == request.Id)
            .ToFarmFinancialSummaryDto()
            .SingleOrNotFoundAsync(nameof(FarmFinancialSummary), request.Id, cancellationToken);
        return result;
    }
}