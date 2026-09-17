namespace InfoManager.ApiClient.Services;

internal class DeviceAlertService(IDeviceAlertApi api) : IDeviceAlertService
{
    public async Task<ApiResult<string>> CreateDeviceAlertAsync(CreateDeviceAlertRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateDeviceAlertAsync(request, ct));

    public async Task<ApiResult> DeleteDeviceAlertAsync(string id, CancellationToken ct = default)
     => await ApiResponseHandler.HandleAsync(await api.DeleteDeviceAlertAsync(id, ct));

    public async Task<ApiResult<DeviceAlertDto?>> GetDeviceAlertByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetDeviceAlertByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<DeviceAlertSummaryDto>>> GetDeviceAlertsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetDeviceAlertsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<DeviceAlertSummaryDto>>> SearchDeviceAlertsAsync(SearchDeviceAlertsRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchDeviceAlertsAsync(request.Term,
                                                                              request.AlertType,
                                                                              request.Severity,
                                                                              request.IsResolved,
                                                                              request.StartAlertTime,
                                                                              request.EndAlertTime,
                                                                              request.PageNumber,
                                                                              request.PageSize,
                                                                              ct));

    public async Task<ApiResult> UpdateDeviceAlertAsync(string id, UpdateDeviceAlertRequest request, CancellationToken ct = default)
     => await ApiResponseHandler.HandleAsync(await api.UpdateDeviceAlertAsync(id, request, ct));
}