namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetGrowthStageAlertsQuery(int PageIndex, int PageSize) : IRequest<Result<PaginatedList<GrowthStageAlertSummaryDto>>>;

public class GetGrowthStageAlertsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetGrowthStageAlertsQuery, Result<PaginatedList<GrowthStageAlertSummaryDto>>>
{
    public async Task<Result<PaginatedList<GrowthStageAlertSummaryDto>>> Handle(GetGrowthStageAlertsQuery request, CancellationToken ct)
    {
        var result = await context.GrowthStageAlerts
            .ApplySorting()
            .ToGrowthStageAlertSummaryDto()
            .PaginatedListAsync(request.PageIndex, request.PageSize, ct);
        return Result<PaginatedList<GrowthStageAlertSummaryDto>>.Success(result);
    }
}