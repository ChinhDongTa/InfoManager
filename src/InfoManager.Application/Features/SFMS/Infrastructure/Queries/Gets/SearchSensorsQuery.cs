namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record SearchSensorsQuery(
    string? Term,
    string? FieldId,
    string? DeviceId,
    SensorType? SensorType,
    DeviceStatus? Status,
    DateTimeOffset? StartInstallationDate,
    DateTimeOffset? EndInstallationDate,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<SensorSummaryDto>>>;

public class SearchSensorsQueryHandler(IApplicationDbContext Context) : IRequestHandler<SearchSensorsQuery, Result<PaginatedList<SensorSummaryDto>>>
{
    public async Task<Result<PaginatedList<SensorSummaryDto>>> Handle(SearchSensorsQuery request, CancellationToken ct)
    {
        var query = Context.Sensors.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToSensorSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<SensorSummaryDto>>.Success(paged);
    }
}