using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Api;

public interface IFarmApi
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
    [Get("/api/Farms/{id}")]
    Task<ApiResponse<FarmDto?>> GetFarmByIdAsync(string id, CancellationToken ct = default);

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
    [Put("/api/Farms/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateFarmAsync(string id, [Body] UpdateFarmRequest request, CancellationToken ct = default);

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
    [Delete("/api/Farms/{id}")]
    Task<IApiResponse> DeleteFarmAsync(string id, CancellationToken ct = default);

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
    [Get("/api/Farms")]
    Task<ApiResponse<PaginatedList<FarmSummaryDto>>> GetFarmsAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

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
    [Post("/api/Farms")]
    Task<ApiResponse<string>> CreateFarmAsync([Body] CreateFarmRequest request, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="minCultivableArea">minCultivableArea parameter</param>
    /// <param name="maxCultivableArea">maxCultivableArea parameter</param>
    /// <param name="status">status parameter</param>
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
    [Get("/api/Farms/search")]
    Task<ApiResponse<PaginatedList<FarmSummaryDto>>> SearchFarmsAsync([Query, AliasAs("Term")] string? term,
                                        [Query, AliasAs("MinCultivableArea")] decimal? minCultivableArea,
                                        [Query, AliasAs("MaxCultivableArea")] decimal? maxCultivableArea,
                                        [Query, AliasAs("Status")] FarmStatus? status,
                                        [Query, AliasAs("PageNumber")] int pageNumber,
                                        [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);
}