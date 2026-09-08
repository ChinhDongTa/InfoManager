using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Services;

public class DeviceService(IDeviceApi api) : IDeviceService
{
   public async Task<ApiResult<string>> CreateDeviceAsync(CreateDeviceRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.CreateDeviceAsync(request, ct));

    public async Task<ApiResult> DeleteDeviceAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteDeviceAsync(id, ct));

    public async Task<ApiResult<DeviceDto?>> GetDeviceByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetDeviceByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<DeviceSummaryDto>>> GetDevicesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetDevicesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<DeviceSummaryDto>>> SearchDevicesAsync(SearchDevicesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchDevicesAsync(request.Term,
                                                                             request.DeviceType,
                                                                             request.DeviceStatus,
                                                                             request.StartInstallationDate,
                                                                             request.EndInstallationDate,
                                                                             request.StartLastMaintenanceDate,
                                                                             request.EndLastMaintenanceDate,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateDeviceAsync(string id, UpdateDeviceRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateDeviceAsync(id, request, ct));
}