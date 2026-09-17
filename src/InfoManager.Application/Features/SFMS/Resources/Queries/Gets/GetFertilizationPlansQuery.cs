namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetFertilizationPlansQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FertilizationPlanSummaryDto>>>;

public class GetFertilizationPlansQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFertilizationPlansQuery, Result<PaginatedList<FertilizationPlanSummaryDto>>>
{
    public async Task<Result<PaginatedList<FertilizationPlanSummaryDto>>> Handle(GetFertilizationPlansQuery request, CancellationToken ct)
    {
        var result = await context.FertilizationPlans
            .ApplySorting()
            .ToFertilizationPlanSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FertilizationPlanSummaryDto>>.Success(result);
    }
}