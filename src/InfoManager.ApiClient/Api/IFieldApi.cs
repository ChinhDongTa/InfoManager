using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Api;

internal interface IFieldApi
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
    [Get("/api/Fields/{id}")]
    Task<ApiResponse<FieldDto?>> GetFieldByIdAsync(string id, CancellationToken ct = default);

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
    [Put("/api/Fields/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateFieldAsync(string id, [Body] UpdateFieldRequest request, CancellationToken ct = default);

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
    [Delete("/api/Fields/{id}")]
    Task<IApiResponse> DeleteFieldAsync(string id, CancellationToken ct = default);

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
    [Get("/api/Fields")]
    Task<ApiResponse<PaginatedList<FieldSummaryDto>>> GetFieldsAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

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
    [Post("/api/Fields")]
    Task<ApiResponse<string>> CreateFieldAsync([Body] CreateFieldRequest request, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="farmId">farmId parameter</param>
    /// <param name="soilCondition">soilCondition parameter</param>
    /// <param name="status">status parameter</param>
    /// <param name="startLastPreparationDate">startLastPreparationDate parameter</param>
    /// <param name="endLastPreparationDate">endLastPreparationDate parameter</param>
    /// <param name="hasIrrigation">hasIrrigation parameter</param>
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
    [Get("/api/Fields/search")]
    Task<ApiResponse<PaginatedList<FieldSummaryDto>>> SearchFieldsAsync([Query, AliasAs("Term")] string? term,
                                         [Query, AliasAs("FarmId")] string? farmId,
                                         [Query, AliasAs("SoilCondition")] SoilCondition? soilCondition,
                                         [Query, AliasAs("Status")] FieldStatus? status,
                                         [Query, AliasAs("StartLastPreparationDate")] System.DateTimeOffset? startLastPreparationDate,
                                         [Query, AliasAs("EndLastPreparationDate")] System.DateTimeOffset? endLastPreparationDate,
                                         [Query, AliasAs("HasIrrigation")] bool? hasIrrigation,
                                         [Query, AliasAs("PageNumber")] int pageNumber,
                                         [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);
}