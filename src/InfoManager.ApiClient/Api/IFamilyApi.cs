using InfoManager.Shared.Dtos.Families;
using InfoManager.Shared.Dtos.FamilyEvents;
using InfoManager.Shared.Dtos.FamilyMembers;
using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.ApiClient.Api;

internal interface IFamilyApi
{
    //==============================Family==============================

    [Get("api/famylies/{id}")]
    Task<ApiResponse<FamilyDto?>> GetFamilyByIdAsync(string id, CancellationToken ct);

    [Get("api/famylies")]
    Task<ApiResponse<PaginatedList<FamilySummaryDto>>> GetFamiliesAsync(int pageNumber, int pageSize, CancellationToken ct);

    [Get("api/famylies/search")]
    Task<ApiResponse<PaginatedList<FamilySummaryDto>>> SearchFamiliesAsync([Query, AliasAs("SearchTerm")] string? searchTerm,
                                                                           [Query, AliasAs("PageNumber")] int pageNumber,
                                                                           [Query, AliasAs("PageSize")] int pageSize,
                                                                           CancellationToken ct);

    [Headers("Content-Type: application/json")]
    [Put("api/famylies/{id}")]
    Task<IApiResponse> UpdateFamilyAsync(string id, [Body] UpdateFamilyRequest request, CancellationToken ct);

    [Headers("Content-Type: application/json")]
    [Post("api/famylies")]
    Task<ApiResponse<string>> CreateFamilyAsync([Body] CreateFamilyRequest request, CancellationToken ct);

    [Delete("api/famylies/{id}")]
    Task<IApiResponse> DeleteFamilyAsync(string id, CancellationToken ct);

    //==============================FamilyEvents==============================

    /// <param name="eventType">eventType parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/FamilyEvents")]
    Task<ApiResponse<PaginatedList<FamilyEventSummaryDto>>> GetFamilyEventsAsync([Query, AliasAs("EventType")] FamilyEventType? eventType,
                                                                         [Query, AliasAs("PageNumber")] int pageNumber,
                                                                         [Query, AliasAs("PageSize")] int pageSize,
                                                                         CancellationToken ct);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/FamilyEvents")]
    Task<ApiResponse<string>> CreateFamilyEventAsync([Body] CreateFamilyEventRequest request, CancellationToken ct);

    /// <param name="memberId">memberId parameter</param>
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
    [Post("/api/FamilyEvents/{memberId}/create-defaults")]
    Task<IApiResponse> CreateDefaultFamilyEventsAsync(string memberId, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/FamilyEvents/{id}")]
    Task<ApiResponse<FamilyEventDto?>> GetFamilyEventByIdAsync(string id, CancellationToken ct);

    [Get("/api/FamilyEvents/{familyMemberId}/select-list")]
    Task<ApiResponse<List<SelectListItemDto>>> GetSelectListFamilyEventsAsync(string familyMemberId, CancellationToken ct = default);

    [Get("/api/FamilyEvents/FamilyMember/{memberId}")]
    Task<ApiResponse<PaginatedList<FamilyEventSummaryDto>>> GetFamilyEventsByMemberIdAsync(string memberId,
                                                                                           int pageNumber,
                                                                                           int pageSize,
                                                                                           CancellationToken ct = default);

    [Post("/api/FamilyMembers/InitDataForUser")]
    Task<ApiResponse<MessageResponse>> InitFamilyEventsForUserAsync([Body] InitDataForUserRequest request, CancellationToken ct = default);

    /// <summary>
    /// Get family event report for a specific month
    /// </summary>
    /// <param name="numMonth">The month up to which to generate the report (1-12)</param>
    /// <param name="ct">The cancellation token</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/FamilyEvents/{NumMonth}/report")]
    Task<ApiResponse<List<FamilyEventReportDto>>> GetFamilyEventReportAsync([Query, AliasAs("NumMonth")] int numMonth, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/FamilyEvents/{id}")]
    Task<IApiResponse> UpdateFamilyEventAsync(string id, [Body] UpdateFamilyEventRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/FamilyEvents/{id}")]
    Task<IApiResponse> DeleteFamilyEventAsync(string id, CancellationToken ct);

    //==============================FamilyMembers==============================

    /// <param name="fullName">fullName parameter</param>
    /// <param name="eventType">eventType parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/FamilyMembers")]
    Task<ApiResponse<PaginatedList<FamilyMemberSummaryDto>>> GetFamilyMembersAsync([Query, AliasAs("FullName")] string? fullName,
                                                                                  [Query, AliasAs("EventType")] FamilyEventType? eventType,
                                                                                  [Query, AliasAs("PageNumber")] int pageNumber,
                                                                                  [Query, AliasAs("PageSize")] int pageSize,
                                                                                  CancellationToken ct);

    /// <param name="command">command parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/FamilyMembers")]
    Task<ApiResponse<string>> CreateFamilyMemberAsync([Body] CreateFamilyMemberRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/FamilyMembers/{id}")]
    Task<ApiResponse<FamilyMemberDto?>> GetFamilyMemberByIdAsync(string id, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/FamilyMembers/{id}")]
    Task<IApiResponse> UpdateFamilyMemberAsync(string id, [Body] UpdateFamilyMemberRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/FamilyMembers/{id}")]
    Task<IApiResponse> DeleteFamilyMemberAsync(string id, CancellationToken ct);

    //==============================FamilyRelations==============================

    /// <param name="name">name parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/FamilyRelations")]
    Task<ApiResponse<PaginatedList<FamilyRelationDto>?>> GetFamilyRelationsAsync([Query] string? name,
                                                                                [Query, AliasAs("PageNumber")] int? pageNumber,
                                                                                [Query, AliasAs("PageSize")] int? pageSize,
                                                                                CancellationToken ct);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/FamilyRelations")]
    Task<ApiResponse<string>> CreateFamilyRelationAsync([Body] CreateFamilyRelationRequest request, CancellationToken ct);

    [Get("/api/FamilyRelations/select-list")]
    Task<ApiResponse<List<SelectListItemDto>>> GetSelectListFamilyRelationsAsync(CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/FamilyRelations/{id}")]
    Task<ApiResponse<FamilyRelationDto?>> GetFamilyRelationByIdAsync(string id, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/FamilyRelations/{id}")]
    Task<IApiResponse> UpdateFamilyRelationAsync(string id, [Body] UpdateFamilyRelationRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/FamilyRelations/{id}")]
    Task<IApiResponse> DeleteFamilyRelationAsync(string id, CancellationToken ct);
}