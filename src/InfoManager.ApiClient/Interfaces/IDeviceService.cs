using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Interfaces;

public interface IDeviceService
{
    Task<ApiResult<DeviceDto?>> GetDeviceByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateDeviceAsync(string id, UpdateDeviceRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteDeviceAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<DeviceSummaryDto>>> GetDevicesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateDeviceAsync(CreateDeviceRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<DeviceSummaryDto>>> SearchDevicesAsync(SearchDevicesRequest request, CancellationToken ct = default);
}