using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Api;

public interface IEquipmentApi
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
    [Get("/api/Equipments/{id}")]
    Task<ApiResponse<EquipmentDto?>> GetEquipmentByIdAsync(string id, CancellationToken ct = default);

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
    [Put("/api/Equipments/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateEquipmentAsync(string id, [Body] UpdateEquipmentRequest request, CancellationToken ct = default);

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
    [Delete("/api/Equipments/{id}")]
    Task<IApiResponse> DeleteEquipmentAsync(string id, CancellationToken ct = default);

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
    [Get("/api/Equipments")]
    Task<ApiResponse<PaginatedList<EquipmentSummaryDto>>> GetEquipmentsAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

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
    [Post("/api/Equipments")]
    Task<ApiResponse<string>> CreateEquipmentAsync([Body] CreateEquipmentRequest request, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="equipmentType">equipmentType parameter</param>
    /// <param name="farmId">farmId parameter</param>
    /// <param name="status">status parameter</param>
    /// <param name="lastMaintenanceDateFrom">lastMaintenanceDateFrom parameter</param>
    /// <param name="lastMaintenanceDateTo">lastMaintenanceDateTo parameter</param>
    /// <param name="nextMaintenanceDateFrom">nextMaintenanceDateFrom parameter</param>
    /// <param name="nextMaintenanceDateTo">nextMaintenanceDateTo parameter</param>
    /// <param name="pageNumeber">pageNumeber parameter</param>
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
    [Get("/api/Equipments/search")]
    Task<ApiResponse<PaginatedList<EquipmentSummaryDto>>> SearchEquipmentsAsync([Query, AliasAs("Term")] string? term,
                                             [Query, AliasAs("EquipmentType")] EquipmentType? equipmentType,
                                             [Query, AliasAs("FarmId")] string? farmId,
                                             [Query, AliasAs("Status")] EquipmentStatus? status,
                                             [Query, AliasAs("LastMaintenanceDateFrom")] System.DateTimeOffset? lastMaintenanceDateFrom,
                                             [Query, AliasAs("LastMaintenanceDateTo")] System.DateTimeOffset? lastMaintenanceDateTo,
                                             [Query, AliasAs("NextMaintenanceDateFrom")] System.DateTimeOffset? nextMaintenanceDateFrom,
                                             [Query, AliasAs("NextMaintenanceDateTo")] System.DateTimeOffset? nextMaintenanceDateTo,
                                             [Query, AliasAs("PageNumber")] int pageNumber,
                                             [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);
}