namespace InfoManager.ApiClient.Interfaces;

public interface IEnvironmentalMonitoringService
{
    Task<ApiResult<EnvironmentalMonitoringDto?>> GetEnvironmentalMonitoringByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateEnvironmentalMonitoringAsync(string id, UpdateEnvironmentalMonitoringRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteEnvironmentalMonitoringAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<EnvironmentalMonitoringSummaryDto>>> GetEnvironmentalMonitoringsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateEnvironmentalMonitoringAsync(CreateEnvironmentalMonitoringRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<EnvironmentalMonitoringSummaryDto>>> SearchEnvironmentalMonitoringsAsync(SearchEnvironmentalMonitoringsRequest request, CancellationToken ct = default);
}
