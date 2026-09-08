using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Api;

public interface IDeviceApi
{
    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/Devices/{id}")]
    Task<ApiResponse<DeviceDto?>> GetDeviceByIdAsync(string id, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Put("/api/Devices/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateDeviceAsync(string id, [Body] UpdateDeviceRequest request, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Delete("/api/Devices/{id}")]
    Task<IApiResponse> DeleteDeviceAsync(string id, CancellationToken ct = default);

    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/Devices")]
    Task<ApiResponse<PaginatedList<DeviceSummaryDto>>> GetDevicesAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Post("/api/Devices")]
    Task<ApiResponse<string>> CreateDeviceAsync([Body] CreateDeviceRequest request, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="deviceType">deviceType parameter</param>
    /// <param name="deviceStatus">deviceStatus parameter</param>
    /// <param name="startInstallationDate">startInstallationDate parameter</param>
    /// <param name="endInstallationDate">endInstallationDate parameter</param>
    /// <param name="startLastMaintenanceDate">startLastMaintenanceDate parameter</param>
    /// <param name="endLastMaintenanceDate">endLastMaintenanceDate parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/Devices/search")]
    Task<ApiResponse<PaginatedList<DeviceSummaryDto>>> SearchDevicesAsync([Query, AliasAs("Term")] string? term,
                                          [Query, AliasAs("DeviceType")] DeviceType? deviceType,
                                          [Query, AliasAs("DeviceStatus")] DeviceStatus? deviceStatus,
                                          [Query, AliasAs("StartInstallationDate")] System.DateTimeOffset? startInstallationDate,
                                          [Query, AliasAs("EndInstallationDate")] System.DateTimeOffset? endInstallationDate,
                                          [Query, AliasAs("StartLastMaintenanceDate")] System.DateTimeOffset? startLastMaintenanceDate,
                                          [Query, AliasAs("EndLastMaintenanceDate")] System.DateTimeOffset? endLastMaintenanceDate,
                                          [Query, AliasAs("PageNumber")] int pageNumber,
                                          [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);
}