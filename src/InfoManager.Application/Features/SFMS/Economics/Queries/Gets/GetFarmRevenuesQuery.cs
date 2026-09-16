namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetFarmRevenuesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FarmRevenueSummaryDto>>>;

public class GetFarmRevenuesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmRevenuesQuery, Result<PaginatedList<FarmRevenueSummaryDto>>>
{
    public async Task<Result<PaginatedList<FarmRevenueSummaryDto>>> Handle(GetFarmRevenuesQuery request, CancellationToken ct)
    {
        var result = await context.FarmRevenues
            .ApplySorting()
            .ToFarmRevenueSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FarmRevenueSummaryDto>>.Success(result);
    }
}