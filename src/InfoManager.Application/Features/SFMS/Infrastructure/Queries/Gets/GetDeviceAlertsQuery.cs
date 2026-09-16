namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetDeviceAlertsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<DeviceAlertSummaryDto>>>;

public class GetDeviceAlertsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetDeviceAlertsQuery, Result<PaginatedList<DeviceAlertSummaryDto>>>
{
    public async Task<Result<PaginatedList<DeviceAlertSummaryDto>>> Handle(GetDeviceAlertsQuery request, CancellationToken ct)
    {
        var result = await context.DeviceAlerts
            .ApplySorting()
            .ToDeviceAlertSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<DeviceAlertSummaryDto>>.Success(result);
    }
}