using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Services;

internal class SensorService(ISensorApi api) : ISensorService
{
    public async Task<ApiResult<string>> CreateSensorAsync(CreateSensorRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.CreateSensorAsync(request, ct));

    public async Task<ApiResult> DeleteSensorAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteSensorAsync(id, ct));

    public async Task<ApiResult<SensorDto?>> GetSensorByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetSensorByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<SensorSummaryDto>>> GetSensorsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetSensorsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<SensorSummaryDto>>> SearchSensorsAsync(SearchSensorsRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchSensorsAsync(request.Term,
                                                                        request.FieldId,
                                                                        request.DeviceId,
                                                                        request.SensorType,
                                                                        request.Status,
                                                                        request.StartInstallationDate,
                                                                        request.EndInstallationDate,
                                                                        request.PageNumber,
                                                                        request.PageSize,
                                                                        ct));

    public async Task<ApiResult> UpdateSensorAsync(string id, UpdateSensorRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateSensorAsync(id, request, ct));
}