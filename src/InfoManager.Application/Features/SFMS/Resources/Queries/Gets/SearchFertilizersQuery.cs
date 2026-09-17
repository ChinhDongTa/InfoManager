using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record SearchFertilizersQuery(string? Term, FertilizerType? FertilizerType, bool? IsActive, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<FertilizerSummaryDto>>>;
public class SearchFertilizersQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchFertilizersQuery, Result<PaginatedList<FertilizerSummaryDto>>>
{
    public async Task<Result<PaginatedList<FertilizerSummaryDto>>> Handle(
        SearchFertilizersQuery request, CancellationToken ct)
    {
        var query = Context.Fertilizers.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToFertilizerSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FertilizerSummaryDto>>.Success(paged);
    }
}