namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetFarmFinancialSummariesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FarmFinancialSummaryDto>>>;
public class GetFarmFinancialSummarysQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmFinancialSummariesQuery, Result<PaginatedList<FarmFinancialSummaryDto>>>
{
    public async Task<Result<PaginatedList<FarmFinancialSummaryDto>>> Handle(GetFarmFinancialSummariesQuery request, CancellationToken cancellationToken)
    {
        var result = await context.FarmFinancialSummaries
            .ApplySorting()
            .ToFarmFinancialSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FarmFinancialSummaryDto>>.Success(result);
    }
}