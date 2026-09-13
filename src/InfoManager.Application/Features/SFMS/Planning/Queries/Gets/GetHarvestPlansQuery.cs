namespace InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

public record GetHarvestPlansQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<HarvestPlanSummaryDto>>>;
public class GetHarvestPlansQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHarvestPlansQuery, Result<PaginatedList<HarvestPlanSummaryDto>>>
{
    public async Task<Result<PaginatedList<HarvestPlanSummaryDto>>> Handle(GetHarvestPlansQuery request, CancellationToken cancellationToken)
    {
        var result = await context.HarvestPlans
            .ApplySorting()
            .ToHarvestPlanSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<HarvestPlanSummaryDto>>.Success(result);
    }
}
