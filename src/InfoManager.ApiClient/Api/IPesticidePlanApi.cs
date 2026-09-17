namespace InfoManager.ApiClient.Api;

internal interface IPesticidePlanApi
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
    [Get("/api/PesticidePlans/{id}")]
    Task<ApiResponse<PesticidePlanDto?>> GetPesticidePlanByIdAsync(string id, CancellationToken ct = default);
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
    [Put("/api/PesticidePlans/{id}")]
    Task<ApiResponse<MessageResponse>> UpdatePesticidePlanAsync(string id, [Body] UpdatePesticidePlanRequest request, CancellationToken ct = default);
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
    [Delete("/api/PesticidePlans/{id}")]
    Task<IApiResponse> DeletePesticidePlanAsync(string id, CancellationToken ct = default);
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
    [Get("/api/PesticidePlans")]
    Task<ApiResponse<PaginatedList<PesticidePlanSummaryDto>>> GetPesticidePlansAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);
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
    [Post("/api/PesticidePlans")]
    Task<ApiResponse<string>> CreatePesticidePlanAsync([Body] CreatePesticidePlanRequest request, CancellationToken ct = default);
    /// <param name="term">term parameter</param>
    /// <param name="farmId">farmId parameter</param>
    /// <param name="pesticideId">pesticideId parameter</param>
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
    [Get("/api/PesticidePlans/search")]
    Task<ApiResponse<PaginatedList<PesticidePlanSummaryDto>>> SearchPesticidePlansAsync([Query, AliasAs("Term")] string? term,
                                          [Query, AliasAs("FarmId")] string? farmId,
                                          [Query, AliasAs("PesticideId")] string? pesticideId,
                                          [Query, AliasAs("Status")] PesticidePlanStatus? status,
                                          [Query, AliasAs("PageNumber")] int pageNumber,
                                          [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);
}
