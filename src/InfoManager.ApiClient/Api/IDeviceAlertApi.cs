namespace InfoManager.ApiClient.Api;

public interface IDeviceAlertApi
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
    [Get("/api/DeviceAlerts/{id}")]
    Task<ApiResponse<DeviceAlertDto?>> GetDeviceAlertByIdAsync(string id, CancellationToken ct = default);

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
    [Put("/api/DeviceAlerts/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateDeviceAlertAsync(string id, [Body] UpdateDeviceAlertRequest request, CancellationToken ct = default);

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
    [Delete("/api/DeviceAlerts/{id}")]
    Task<IApiResponse> DeleteDeviceAlertAsync(string id, CancellationToken ct = default);

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
    [Get("/api/DeviceAlerts")]
    Task<ApiResponse<PaginatedList<DeviceAlertSummaryDto>>> GetDeviceAlertsAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

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
    [Post("/api/DeviceAlerts")]
    Task<ApiResponse<string>> CreateDeviceAlertAsync([Body] CreateDeviceAlertRequest request, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="alertType">alertType parameter</param>
    /// <param name="severity">severity parameter</param>
    /// <param name="isResolved">isResolved parameter</param>
    /// <param name="startAlertTime">startAlertTime parameter</param>
    /// <param name="endAlertTime">endAlertTime parameter</param>
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
    [Get("/api/DeviceAlerts/search")]
    Task<ApiResponse<PaginatedList<DeviceAlertSummaryDto>>> SearchDeviceAlertsAsync([Query, AliasAs("Term")] string? term,
                                               [Query, AliasAs("AlertType")] AlertType? alertType,
                                               [Query, AliasAs("Severity")] AlertSeverity? severity,
                                               [Query, AliasAs("IsResolved")] bool? isResolved,
                                               [Query, AliasAs("StartAlertTime")] System.DateTimeOffset? startAlertTime,
                                               [Query, AliasAs("EndAlertTime")] System.DateTimeOffset? endAlertTime,
                                               [Query, AliasAs("PageNumber")] int pageNumber,
                                               [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);
}