namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record SearchFarmsQuery(string? Term,
                                decimal? MinCultivableArea,
                                decimal? MaxCultivableArea,
                                FarmStatus? Status,
                                int PageNumber,
                                int PageSize) : IRequest<Result<PaginatedList<FarmSummaryDto>>>;

public class SearchFarmsQueryHandler(IApplicationDbContext Context) : IRequestHandler<SearchFarmsQuery, Result<PaginatedList<FarmSummaryDto>>>
{
    public async Task<Result<PaginatedList<FarmSummaryDto>>> Handle(SearchFarmsQuery request, CancellationToken ct)
    {
        var query = Context.Farms.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToFarmSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FarmSummaryDto>>.Success(paged);
    }
}