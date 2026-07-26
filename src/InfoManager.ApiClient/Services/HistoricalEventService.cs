using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.ApiClient.Services;

public class HistoricalEventService(IHistoricalEventApi api) : IHistoricalEventService
{
   public  async Task<ApiResult<string>> CreateHistoricalEventAsync(CreateHistoricalEventRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.CreateHistoricalEventAsync(request, ct));
    }

   public  async Task<ApiResult<MessageResponse>> DeleteHistoricalEventAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.DeleteHistoricalEventAsync(id,ct));
    }

   public  async Task<ApiResult<HistoricalEventDto?>> GetHistoricalEventByIdAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetHistoricalEventByIdAsync(id, ct));
    }

   public  async Task<ApiResult<PaginatedList<HistoricalEventSummaryDto>>> GetHistoricalEventsAsync(int pageNumber = 1, int pageSize = 20, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetHistoricalEventsAsync(pageNumber, pageSize, ct));
    }

   public  async Task<ApiResult<HistoricalEventSummaryDto>> GetNextMonthHistoricalEventsAsync(int numMonths, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetNextMonthHistoricalEventsAsync(numMonths, ct));
    }

   public  async Task<ApiResult<PaginatedList<HistoricalEventSummaryDto>>> SearchHistoricalEventsAsync(SearchHistoricalEventRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.SearchHistoricalEventsAsync(request.SearchTerm, request.StartDate, request.EndDate, request.PageNumber, request.PageSize, ct));
    }

   public  async Task<ApiResult<MessageResponse>> UpdateHistoricalEventAsync(string id, UpdateHistoricalEventRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.UpdateHistoricalEventAsync(id, request, ct));
    }
}
