using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

public record SearchPlantingPlansQuery(
    string? Term,
    PlanStatus? Status,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<PlantingPlanSummaryDto>>>;
public class SearchPlantingPlansQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchPlantingPlansQuery, Result<PaginatedList<PlantingPlanSummaryDto>>>
{
    public async Task<Result<PaginatedList<PlantingPlanSummaryDto>>> Handle(
        SearchPlantingPlansQuery request, CancellationToken cancellationToken)
    {
        var query = Context.PlantingPlans.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToPlantingPlanSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<PlantingPlanSummaryDto>>.Success(paged);
    }
}