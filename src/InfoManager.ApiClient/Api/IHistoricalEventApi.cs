using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.ApiClient.Api;

public interface IHistoricalEventApi
{
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/HistoricalEvents")]
    Task<ApiResponse<PaginatedList<HistoricalEventSummaryDto>>> GetHistoricalEventsAsync([Query] int pageNumber, [Query] int pageSize,CancellationToken ct);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/HistoricalEvents")]
    Task<ApiResponse<string>> CreateHistoricalEventAsync([Body] CreateHistoricalEventRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/HistoricalEvents/{id}")]
    Task<ApiResponse<HistoricalEventDto?>> GetHistoricalEventByIdAsync(string id, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/HistoricalEvents/{id}")]
    Task<IApiResponse> UpdateHistoricalEventAsync(string id, [Body] UpdateHistoricalEventRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/HistoricalEvents/{id}")]
    Task<IApiResponse> DeleteHistoricalEventAsync(string id, CancellationToken ct);

    /// <param name="numMonths">numMonths parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/HistoricalEvents/next/{numMonths}")]
    Task<ApiResponse<List<HistoricalEventSummaryDto>>> GetNextMonthHistoricalEventsAsync(int numMonths, CancellationToken ct);

    /// <param name="searchTerm">searchTerm parameter</param>
    /// <param name="startDate">startDate parameter</param>
    /// <param name="endDate">endDate parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/HistoricalEvents/search")]
    Task<ApiResponse<PaginatedList<HistoricalEventSummaryDto>>> SearchHistoricalEventsAsync(
        [Query, AliasAs("SearchTerm")] string? searchTerm, [Query, AliasAs("StartDate")] System.DateOnly? startDate,
        [Query, AliasAs("EndDate")] System.DateOnly? endDate, [Query, AliasAs("PageNumber")] int pageNumber,
        [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct);

}
