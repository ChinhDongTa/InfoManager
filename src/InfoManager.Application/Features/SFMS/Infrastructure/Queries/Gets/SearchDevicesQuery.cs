namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record SearchDevicesQuery(string? Term,
    DeviceType? DeviceType,
    DeviceStatus? DeviceStatus,
    DateTimeOffset? StartInstallationDate,
    DateTimeOffset? EndInstallationDate,
    DateTimeOffset? StartLastMaintenanceDate,
    DateTimeOffset? EndLastMaintenanceDate,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<DeviceSummaryDto>>>;

public class SearchDevicesQueryHandler(IApplicationDbContext Context) : IRequestHandler<SearchDevicesQuery, Result<PaginatedList<DeviceSummaryDto>>>
{
    public async Task<Result<PaginatedList<DeviceSummaryDto>>> Handle(SearchDevicesQuery request, CancellationToken ct)
    {
        var query = Context.Devices.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToDeviceSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<DeviceSummaryDto>>.Success(paged);
    }
}