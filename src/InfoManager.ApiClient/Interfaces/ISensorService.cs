using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Interfaces;

public interface ISensorService
{
    Task<ApiResult<SensorDto?>> GetSensorByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateSensorAsync(string id, UpdateSensorRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteSensorAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<SensorSummaryDto>>> GetSensorsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateSensorAsync(CreateSensorRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<SensorSummaryDto>>> SearchSensorsAsync(SearchSensorsRequest request, CancellationToken ct = default);
}