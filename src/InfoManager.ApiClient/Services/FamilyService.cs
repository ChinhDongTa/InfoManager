using InfoManager.Shared.Dtos.Families;
using InfoManager.Shared.Dtos.FamilyEvents;
using InfoManager.Shared.Dtos.FamilyMembers;
using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.ApiClient.Services;

internal class FamilyService(IFamilyApi api) : IFamilyService
{
    public async Task<ApiResult<string>> CreateFamilyMemberAsync(CreateFamilyMemberRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.CreateFamilyMemberAsync(request, ct));

    public async Task<ApiResult> CreateDefaultFamilyEventsAsync(string memberId, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.CreateDefaultFamilyEventsAsync(memberId, ct));

    public async Task<ApiResult<string>> CreateFamilyEventAsync(CreateFamilyEventRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.CreateFamilyEventAsync(request, ct));

    public async Task<ApiResult<string>> CreateFamilyRelationAsync(CreateFamilyRelationRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.CreateFamilyRelationAsync(request, ct));

    public async Task<ApiResult> DeleteFamilyRelationAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.DeleteFamilyRelationAsync(id, ct));

    public async Task<ApiResult> DeleteFamilyEventAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.DeleteFamilyEventAsync(id, ct));

    public async Task<ApiResult> DeleteFamilyMemberAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.DeleteFamilyMemberAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FamilyMemberSummaryDto>>> GetFamilyMembersAsync(string? fullName,
                                                                                               FamilyEventType? eventType,
                                                                                               int pageNumber,
                                                                                               int pageSize,
                                                                                               CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyMembersAsync(fullName, eventType, pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FamilyEventSummaryDto>>> GetFamilyEventsByMemberIdAsync(string familyMemberId,
                                                                                                      int pageNumber,
                                                                                                      int pageSize,
                                                                                                      CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyEventsByMemberIdAsync(familyMemberId, pageNumber, pageSize, ct));

    public async Task<ApiResult<FamilyMemberDto?>> GetFamilyMemberByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyMemberByIdAsync(id, ct));

    public async Task<ApiResult<FamilyEventDto?>> GetFamilyEventByIdAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetFamilyEventByIdAsync(id, ct));
    }

    public async Task<ApiResult<PaginatedList<FamilyEventSummaryDto>>> GetFamilyEventsAsync(FamilyEventType? eventType,
                                                                                             int pageNumber,
                                                                                             int pageSize,
                                                                                             CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyEventsAsync(eventType, pageNumber, pageSize, ct));

    public async Task<ApiResult<FamilyRelationDto?>> GetFamilyRelationByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyRelationByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FamilyRelationDto>?>> GetFamilyRelationsAsync(string? name,
                                                                                            int pageNumber,
                                                                                            int pageSize,
                                                                                            CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyRelationsAsync(name, pageNumber, pageSize, ct));

    public async Task<ApiResult> UpdateFamilyMemberAsync(string id, UpdateFamilyMemberRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.UpdateFamilyMemberAsync(id, request, ct));

    public async Task<ApiResult> UpdateFamilyEventAsync(string id, UpdateFamilyEventRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.UpdateFamilyEventAsync(id, request, ct));

    public async Task<ApiResult> UpdateFamilyRelationAsync(string id, UpdateFamilyRelationRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.UpdateFamilyRelationAsync(id, request, ct));
    }

    public async Task<ApiResult<List<SelectListItemDto>>> GetSelectListFamilyEventsAsync(string familyMemberId, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetSelectListFamilyEventsAsync(familyMemberId, ct));

    public async Task<ApiResult<List<SelectListItemDto>>> GetSelectListFamilyRelationsAsync(CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetSelectListFamilyRelationsAsync(ct));

    public async Task<ApiResult<List<FamilyEventReportDto>>> GetFamilyEventReportAsync(int numMonth, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyEventReportAsync(numMonth, ct));

    //====================== Family ======================
    public async Task<ApiResult<FamilyDto?>> GetFamilyByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FamilySummaryDto>>> GetFamiliesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamiliesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FamilySummaryDto>>> SearchFamiliesAsync(string? keyword,
                                                                                      int pageNumber,
                                                                                      int pageSize,
                                                                                      CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.SearchFamiliesAsync(keyword, pageNumber, pageSize, ct));

    public async Task<ApiResult> UpdateFamilyAsync(string id, UpdateFamilyRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.UpdateFamilyAsync(id, request, ct));

    public async Task<ApiResult> DeleteFamilyAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.DeleteFamilyAsync(id, ct));

    public async Task<ApiResult<string>> CreateFamilyAsync(CreateFamilyRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.CreateFamilyAsync(request, ct));

    public async Task<ApiResult<MessageResponse>> InitFamilyEventsForUserAsync(InitDataForUserRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.InitFamilyEventsForUserAsync(request, ct));
}