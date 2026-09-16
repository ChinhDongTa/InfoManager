using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Api;

public interface ISensorApi
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
    [Get("/api/Sensors/{id}")]
    Task<ApiResponse<SensorDto?>> GetSensorByIdAsync(string id, CancellationToken ct = default);

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
    [Put("/api/Sensors/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateSensorAsync(string id, [Body] UpdateSensorRequest request, CancellationToken ct = default);

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
    [Delete("/api/Sensors/{id}")]
    Task<IApiResponse> DeleteSensorAsync(string id, CancellationToken ct = default);

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
    [Get("/api/Sensors")]
    Task<ApiResponse<PaginatedList<SensorSummaryDto>>> GetSensorsAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

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
    [Post("/api/Sensors")]
    Task<ApiResponse<string>> CreateSensorAsync([Body] CreateSensorRequest request, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="fieldId">fieldId parameter</param>
    /// <param name="deviceId">deviceId parameter</param>
    /// <param name="sensorType">sensorType parameter</param>
    /// <param name="status">status parameter</param>
    /// <param name="startInstallationDate">startInstallationDate parameter</param>
    /// <param name="endInstallationDate">endInstallationDate parameter</param>
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
    [Get("/api/Sensors/search")]
    Task<ApiResponse<PaginatedList<SensorSummaryDto>>> SearchSensorsAsync([Query, AliasAs("Term")] string? term,
                                          [Query, AliasAs("FieldId")] string? fieldId,
                                          [Query, AliasAs("DeviceId")] string? deviceId,
                                          [Query, AliasAs("SensorType")] SensorType? sensorType,
                                          [Query, AliasAs("Status")] DeviceStatus? status,
                                          [Query, AliasAs("StartInstallationDate")] System.DateTimeOffset? startInstallationDate,
                                          [Query, AliasAs("EndInstallationDate")] System.DateTimeOffset? endInstallationDate,
                                          [Query, AliasAs("PageNumber")] int pageNumber,
                                          [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);
}