namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record SearchDeviceAlertsQuery(string? Term,
    AlertType? AlertType,
    AlertSeverity? Severity,
    bool? IsResolved,
    DateTimeOffset? StartAlertTime,
    DateTimeOffset? EndAlertTime,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<DeviceAlertSummaryDto>>>;

public class SearchDeviceAlertsQueryHandler(IApplicationDbContext Context) : IRequestHandler<SearchDeviceAlertsQuery, Result<PaginatedList<DeviceAlertSummaryDto>>>
{
    public async Task<Result<PaginatedList<DeviceAlertSummaryDto>>> Handle(SearchDeviceAlertsQuery request, CancellationToken ct)
    {
        var query = Context.DeviceAlerts.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToDeviceAlertSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<DeviceAlertSummaryDto>>.Success(paged);
    }
}