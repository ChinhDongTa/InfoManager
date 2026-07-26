using InfoManager.Shared.Dtos.FamilyEvents;
using InfoManager.Shared.Dtos.FamilyMembers;
using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.ApiClient.Api;

public interface IFamilyApi
{
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

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/FamilyEvents/{id}")]
   Task<ApiResponse<FamilyEventDto?>> GetFamilyEventByIdAsync(string id,CancellationToken ct);

    [Get("/api/FamilyEvents/{familyMemberId}/select-list")]
    Task<ApiResponse<List<SelectListItemDto>>> GetSelectListFamilyEventsAsync(string familyMemberId, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/FamilyEvents/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateFamilyEventAsync(string id, [Body] UpdateFamilyEventRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/FamilyEvents/{id}")]
    Task<ApiResponse<MessageResponse>> DeleteFamilyEventAsync(string id, CancellationToken ct);

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
    Task<ApiResponse<MessageResponse>> UpdateFamilyMemberAsync(string id, [Body] UpdateFamilyMemberRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/FamilyMembers/{id}")]
    Task<ApiResponse<MessageResponse>> DeleteFamilyMemberAsync(string id, CancellationToken ct);

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
    Task<ApiResponse<MessageResponse>> UpdateFamilyRelationAsync(string id, [Body] UpdateFamilyRelationRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/FamilyRelations/{id}")]
    Task<ApiResponse<MessageResponse>> DeleteFamilyRelationAsync(string id, CancellationToken ct);
}
