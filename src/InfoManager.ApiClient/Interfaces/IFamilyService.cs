using InfoManager.Shared.Dtos.FamilyEvents;
using InfoManager.Shared.Dtos.FamilyMembers;
using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.ApiClient.Interfaces;

public interface IFamilyService
{
    Task<ApiResult<PaginatedList<FamilyEventSummaryDto>>> GetFamilyEventsAsync(FamilyEventType? eventType, int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateFamilyEventAsync(CreateFamilyEventRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> UpdateFamilyEventAsync(string id, UpdateFamilyEventRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> DeleteFamilyEventAsync(string id, CancellationToken ct = default);
    Task<ApiResult<FamilyEventDto?>> GetFamilyEventByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<List<SelectListItemDto>>> GetSelectListFamilyEventsAsync(string familyMemberId, CancellationToken ct = default);


    Task<ApiResult<FamilyMemberDto?>> GetFamilyMemberByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> UpdateFamilyMemberAsync(string id, UpdateFamilyMemberRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> DeleteFamilyMemberAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<FamilyMemberSummaryDto>>> GetFamilyMembersAsync(string? fullName, FamilyEventType? eventType, int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateFamilyMemberAsync(CreateFamilyMemberRequest request, CancellationToken ct = default);
    //Task<ApiResult<PaginatedList<FamilyMemberSummaryDto>>> SearchFamilyMembersAsync(string? keyword, string? categoryId, int pageNumber, int pageSize, CancellationToken ct = default);


    Task<ApiResult<PaginatedList<FamilyRelationDto>?>> GetFamilyRelationsAsync(string? name, int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<List<SelectListItemDto>>> GetSelectListFamilyRelationsAsync(CancellationToken ct = default);
    Task<ApiResult<FamilyRelationDto?>> GetFamilyRelationByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> UpdateFamilyRelationAsync(string id, UpdateFamilyRelationRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> DeleteFamilyRelationAsync(string id, CancellationToken ct = default);
    Task<ApiResult<string>> CreateFamilyRelationAsync(CreateFamilyRelationRequest request, CancellationToken ct = default);
}