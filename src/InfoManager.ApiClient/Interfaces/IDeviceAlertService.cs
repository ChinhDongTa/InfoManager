namespace InfoManager.ApiClient.Interfaces;

public interface IDeviceAlertService
{
    Task<ApiResult<DeviceAlertDto?>> GetDeviceAlertByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateDeviceAlertAsync(string id,UpdateDeviceAlertRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteDeviceAlertAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<DeviceAlertSummaryDto>>> GetDeviceAlertsAsync( int pageNumber,int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateDeviceAlertAsync( CreateDeviceAlertRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<DeviceAlertSummaryDto>>> SearchDeviceAlertsAsync(SearchDeviceAlertsRequest request, CancellationToken ct = default);
}
