namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetFarmFinancialSummariesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FarmFinancialSummaryDto>>>;

public class GetFarmFinancialSummarysQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmFinancialSummariesQuery, Result<PaginatedList<FarmFinancialSummaryDto>>>
{
    public async Task<Result<PaginatedList<FarmFinancialSummaryDto>>> Handle(GetFarmFinancialSummariesQuery request, CancellationToken ct)
    {
        var result = await context.FarmFinancialSummaries
            .ApplySorting()
            .ToFarmFinancialSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FarmFinancialSummaryDto>>.Success(result);
    }
}