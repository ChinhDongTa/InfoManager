namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record SearchGrowthStageAlertsQuery(string? CropPlantingId,
    string? GrowthStageId,
    GrowthAlertType? AlertType,
    AlertSeverity? Severity,
    bool? IsResolved,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<GrowthStageAlertSummaryDto>>>;
public class SearchGrowthStageAlertsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchGrowthStageAlertsQuery, Result<PaginatedList<GrowthStageAlertSummaryDto>>>
{
    public async Task<Result<PaginatedList<GrowthStageAlertSummaryDto>>> Handle(SearchGrowthStageAlertsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<GrowthStageAlert> query = BuildSearchQuery(request);
        var result = await query
            .ApplySorting()
            .ToGrowthStageAlertSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<GrowthStageAlertSummaryDto>>.Success(result);
    }

    private IQueryable<GrowthStageAlert> BuildSearchQuery(SearchGrowthStageAlertsQuery request)
    {
        var query = context.GrowthStageAlerts.AsQueryable();
        if (!string.IsNullOrEmpty(request.CropPlantingId))
        {
            query = query.Where(x => x.CropPlantingId == request.CropPlantingId);
        }
        if (!string.IsNullOrEmpty(request.GrowthStageId))
        {
            query = query.Where(x => x.GrowthStageId == request.GrowthStageId);
        }
        if (request.AlertType.HasValue)
        {
            query = query.Where(x => x.AlertType == request.AlertType.Value);
        }
        if (request.Severity.HasValue)
        {
            query = query.Where(x => x.Severity == request.Severity.Value);
        }
        if (request.IsResolved.HasValue)
        {
            query = query.Where(x => x.IsResolved == request.IsResolved.Value);
        }

        return query;
    }
}