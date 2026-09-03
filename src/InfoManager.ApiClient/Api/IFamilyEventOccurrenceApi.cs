using InfoManager.Shared.Dtos.FamilyEventOccurrences;

namespace InfoManager.ApiClient.Api;

public interface IFamilyEventOccurrenceApi
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
    [Get("/api/FamilyEventOccurrences/{id}")]
    Task<ApiResponse<FamilyEventOccurrenceDto?>> GetFamilyEventOccurrenceByIdAsync(string id, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="command">command parameter</param>
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
    [Put("/api/FamilyEventOccurrences/{id}")]
    Task<IApiResponse> UpdateFamilyEventOccurrenceAsync(string id, [Body] UpdateFamilyEventOccurrenceRequest dto, CancellationToken ct = default);

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
    [Delete("/api/FamilyEventOccurrences/{id}")]
    Task<IApiResponse> DeleteFamilyEventOccurrenceAsync(string id, CancellationToken ct = default);

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
    [Get("/api/FamilyEventOccurrences/{id}/member")]
    Task<ApiResponse<PaginatedList<FamilyEventOccurrenceSummaryDto>>> GetFamilyEventOccurrenceByMemberIdAsync(string memberId, int pageNumber, int pageSize, CancellationToken ct = default);

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
    [Get("/api/FamilyEventOccurrences")]
    Task<ApiResponse<PaginatedList<FamilyEventOccurrenceSummaryDto>>> GetFamilyEventOccurrencesAsync([Query] int? pageNumber, [Query] int? pageSize, CancellationToken ct = default);

    /// <param name="command">command parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="ApiResponse"/> instance containing the result:
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
    [Post("/api/FamilyEventOccurrences")]
    Task<ApiResponse<string>> CreateFamilyEventOccurrenceAsync([Body] CreateFamilyEventOccurrenceRequest dto, CancellationToken ct = default);

    /// <param name="searchTerm">searchTerm parameter</param>
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
    [Get("/api/FamilyEventOccurrences/search")]
    Task<ApiResponse<PaginatedList<FamilyEventOccurrenceSummaryDto>>> SearchFamilyEventOccurrencesAsync([Query] string searchTerm, [Query] int? pageNumber, [Query] int? pageSize, CancellationToken ct = default);
}
