using InfoManager.Shared.Dtos.Families;
using InfoManager.Shared.Dtos.FamilyEvents;
using InfoManager.Shared.Dtos.FamilyMembers;
using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.ApiClient.Interfaces;

public interface IFamilyService
{
    //====================== Family ======================
    Task<ApiResult<FamilyDto?>> GetFamilyByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FamilySummaryDto>>> GetFamiliesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FamilySummaryDto>>> SearchFamiliesAsync(string? keyword, int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult> UpdateFamilyAsync(string id, UpdateFamilyRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFamilyAsync(string id, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFamilyAsync(CreateFamilyRequest request, CancellationToken ct = default);

    //====================== Family Events ======================
    Task<ApiResult<PaginatedList<FamilyEventSummaryDto>>> GetFamilyEventsAsync(FamilyEventType? eventType, int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFamilyEventAsync(CreateFamilyEventRequest request, CancellationToken ct = default);

    Task<ApiResult> CreateDefaultFamilyEventsAsync(string memberId, CancellationToken ct = default);

    Task<ApiResult> UpdateFamilyEventAsync(string id, UpdateFamilyEventRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFamilyEventAsync(string id, CancellationToken ct = default);

    Task<ApiResult<FamilyEventDto?>> GetFamilyEventByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult<List<SelectListItemDto>>> GetSelectListFamilyEventsAsync(string familyMemberId, CancellationToken ct = default);

    Task<ApiResult<List<FamilyEventReportDto>>> GetFamilyEventReportAsync(int numMonth, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FamilyEventSummaryDto>>> GetFamilyEventsByMemberIdAsync(string familyMemberId, int pageNumber, int pageSize, CancellationToken ct = default);

    //====================== Family Members ======================
    Task<ApiResult<FamilyMemberDto?>> GetFamilyMemberByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFamilyMemberAsync(string id, UpdateFamilyMemberRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFamilyMemberAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FamilyMemberSummaryDto>>> GetFamilyMembersAsync(string? fullName, FamilyEventType? eventType, int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFamilyMemberAsync(CreateFamilyMemberRequest request, CancellationToken ct = default);

    Task<ApiResult<MessageResponse>> InitFamilyEventsForUserAsync(InitDataForUserRequest request, CancellationToken ct = default);

    //====================== Family Relations ======================
    Task<ApiResult<PaginatedList<FamilyRelationDto>?>> GetFamilyRelationsAsync(string? name, int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<List<SelectListItemDto>>> GetSelectListFamilyRelationsAsync(CancellationToken ct = default);

    Task<ApiResult<FamilyRelationDto?>> GetFamilyRelationByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFamilyRelationAsync(string id, UpdateFamilyRelationRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFamilyRelationAsync(string id, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFamilyRelationAsync(CreateFamilyRelationRequest request, CancellationToken ct = default);
}