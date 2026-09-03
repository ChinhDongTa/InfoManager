using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.ApiClient.Interfaces;

public interface IHistoricalEventService
{
    Task<ApiResult<PaginatedList<HistoricalEventSummaryDto>>> GetHistoricalEventsAsync(int pageNumber = 1, int pageSize = 20, CancellationToken ct = default);
    Task<ApiResult<List<HistoricalEventSummaryDto>>> GetNextMonthHistoricalEventsAsync(int numMonths, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<HistoricalEventSummaryDto>>> SearchHistoricalEventsAsync(SearchHistoricalEventRequest request, CancellationToken ct = default);
    Task<ApiResult<HistoricalEventDto?>> GetHistoricalEventByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<string>> CreateHistoricalEventAsync(CreateHistoricalEventRequest request, CancellationToken ct = default);
    Task<ApiResult> UpdateHistoricalEventAsync(string id, UpdateHistoricalEventRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteHistoricalEventAsync(string id, CancellationToken ct=default);
}
