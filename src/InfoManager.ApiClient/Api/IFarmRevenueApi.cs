namespace InfoManager.ApiClient.Api;

internal interface IFarmRevenueApi
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
    [Get("/api/FarmRevenues/{id}")]
    Task<ApiResponse<FarmRevenueDto?>> GetFarmRevenueByIdAsync(string id, CancellationToken ct = default);
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
    [Put("/api/FarmRevenues/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateFarmRevenueAsync(string id, [Body] UpdateFarmRevenueRequest request, CancellationToken ct = default);
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
    [Delete("/api/FarmRevenues/{id}")]
    Task<IApiResponse> DeleteFarmRevenueAsync(string id, CancellationToken ct = default);
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
    [Get("/api/FarmRevenues")]
    Task<ApiResponse<PaginatedList<FarmRevenueSummaryDto>>> GetFarmRevenuesAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);
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
    [Post("/api/FarmRevenues")]
    Task<ApiResponse<string>> CreateFarmRevenueAsync([Body] CreateFarmRevenueRequest request, CancellationToken ct = default);
    /// <param name="term">term parameter</param>
    /// <param name="farmId">farmId parameter</param>
    /// <param name="cropPlantingId">cropPlantingId parameter</param>
    /// <param name="harvestId">harvestId parameter</param>
    /// <param name="saleId">saleId parameter</param>
    /// <param name="paymentStatus">paymentStatus parameter</param>
    /// <param name="startRevenueDate">startRevenueDate parameter</param>
    /// <param name="endRevenueDate">endRevenueDate parameter</param>
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
    [Get("/api/FarmRevenues/search")]
    Task<ApiResponse<PaginatedList<FarmRevenueSummaryDto>>> SearchFarmRevenuesAsync([Query, AliasAs("Term")] string? term,
                                          [Query, AliasAs("FarmId")] string? farmId,
                                          [Query, AliasAs("CropPlantingId")] string? cropPlantingId,
                                          [Query, AliasAs("HarvestId")] string? harvestId,
                                          [Query, AliasAs("SaleId")] string? saleId,
                                          [Query, AliasAs("PaymentStatus")] PaymentStatus? paymentStatus,
                                          [Query, AliasAs("StartRevenueDate")] System.DateTimeOffset? startRevenueDate,
                                          [Query, AliasAs("EndRevenueDate")] System.DateTimeOffset? endRevenueDate,
                                          [Query, AliasAs("PageNumber")] int pageNumber,
                                          [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);
}
