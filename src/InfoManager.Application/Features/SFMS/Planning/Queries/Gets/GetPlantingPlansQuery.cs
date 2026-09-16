namespace InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

public record GetPlantingPlansQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<PlantingPlanSummaryDto>>>;

public class GetPlantingPlansQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPlantingPlansQuery, Result<PaginatedList<PlantingPlanSummaryDto>>>
{
    public async Task<Result<PaginatedList<PlantingPlanSummaryDto>>> Handle(GetPlantingPlansQuery request, CancellationToken ct)
    {
        var result = await context.PlantingPlans
            .ApplySorting()
            .ToPlantingPlanSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PlantingPlanSummaryDto>>.Success(result);
    }
}