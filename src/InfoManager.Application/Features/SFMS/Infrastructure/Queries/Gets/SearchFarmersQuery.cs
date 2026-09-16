namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record SearchFarmersQuery(string? Term, int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FarmerSummaryDto>>>;

public class SearchFarmersQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchFarmersQuery, Result<PaginatedList<FarmerSummaryDto>>>
{
    public async Task<Result<PaginatedList<FarmerSummaryDto>>> Handle(SearchFarmersQuery request, CancellationToken ct)
    {
        var query = context.Farmers.AsQueryable().BuildSearchQuery(request);

        var paginatedResult = await query.ApplySorting()
            .ToFarmerSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FarmerSummaryDto>>.Success(paginatedResult);
    }
}