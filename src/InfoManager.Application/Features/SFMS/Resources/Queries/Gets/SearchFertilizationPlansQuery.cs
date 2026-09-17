using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record SearchFertilizationPlansQuery(string? Term, string? FarmId, string? FertilizerId, FertilizationPlanStatus? Status, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<FertilizationPlanSummaryDto>>>;
public class SearchFertilizationPlansQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchFertilizationPlansQuery, Result<PaginatedList<FertilizationPlanSummaryDto>>>
{
    public async Task<Result<PaginatedList<FertilizationPlanSummaryDto>>> Handle(
        SearchFertilizationPlansQuery request, CancellationToken ct)
    {
        var query = Context.FertilizationPlans.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToFertilizationPlanSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FertilizationPlanSummaryDto>>.Success(paged);
    }
}