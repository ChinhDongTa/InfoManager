using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

public record SearchHarvestPlansQuery(
    string? Term,
    DateTimeOffset? ExpectedDate,
    PlanStatus? Status,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<HarvestPlanSummaryDto>>>;
public class SearchHarvestPlansQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchHarvestPlansQuery, Result<PaginatedList<HarvestPlanSummaryDto>>>
{
    public async Task<Result<PaginatedList<HarvestPlanSummaryDto>>> Handle(
        SearchHarvestPlansQuery request, CancellationToken cancellationToken)
    {
        var query = Context.HarvestPlans.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToHarvestPlanSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<HarvestPlanSummaryDto>>.Success(paged);
    }
}