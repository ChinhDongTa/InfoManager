namespace InfoManager.ApiClient.Api;

public interface IPestApi
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
    [Get("/api/Pests/{id}")]
    Task<ApiResponse<PestDto?>> GetPestByIdAsync(string id, CancellationToken ct = default);
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
    [Put("/api/Pests/{id}")]
    Task<ApiResponse<MessageResponse>> UpdatePestAsync(string id, [Body] UpdatePestRequest request, CancellationToken ct = default);
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
    [Delete("/api/Pests/{id}")]
    Task<IApiResponse> DeletePestAsync(string id, CancellationToken ct = default);
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
    [Get("/api/Pests")]
    Task<ApiResponse<PaginatedList<PestSummaryDto>>> GetPestsAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);
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
    [Post("/api/Pests")]
    Task<ApiResponse<string>> CreatePestAsync([Body] CreatePestRequest request, CancellationToken ct = default);
    /// <param name="term">term parameter</param>
    /// <param name="pestType">pestType parameter</param>
    /// <param name="severityLevel">severityLevel parameter</param>
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
    [Get("/api/Pests/search")]
    Task<ApiResponse<PaginatedList<PestSummaryDto>>> SearchPestsAsync([Query, AliasAs("Term")] string? term,
                                          [Query, AliasAs("PestType")] string? pestType,
                                          [Query, AliasAs("SeverityLevel")] SeverityLevel? severityLevel,
                                          [Query, AliasAs("PageNumber")] int pageNumber,
                                          [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);
}
