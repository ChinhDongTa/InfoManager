using InfoManager.Shared.Dtos.FamilyEvents;
using InfoManager.Shared.Dtos.FamilyMembers;
using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.ApiClient.Services;

public class FamilyService(IFamilyApi api) : IFamilyService
{
   public  async Task<ApiResult<string>> CreateFamilyMemberAsync(CreateFamilyMemberRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.CreateFamilyMemberAsync(request, ct));
    }

   public  async Task<ApiResult<string>> CreateFamilyEventAsync(CreateFamilyEventRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.CreateFamilyEventAsync(request, ct));
    }

   public  async Task<ApiResult<string>> CreateFamilyRelationAsync(CreateFamilyRelationRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.CreateFamilyRelationAsync(request, ct));
    }

   public  async Task<ApiResult<MessageResponse>> DeleteFamilyRelationAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.DeleteFamilyEventAsync(id, ct));
    }

   public  async Task<ApiResult<MessageResponse>> DeleteFamilyEventAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.DeleteFamilyEventAsync(id, ct));
    }

   public  async Task<ApiResult<MessageResponse>> DeleteFamilyMemberAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.DeleteFamilyMemberAsync(id, ct));
    }

   public  async Task<ApiResult<PaginatedList<FamilyMemberSummaryDto>>> GetFamilyMembersAsync(string? fullName,
                                                                                              FamilyEventType? eventType,
                                                                                              int pageNumber,
                                                                                              int pageSize,
                                                                                              CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetFamilyMembersAsync(fullName, eventType, pageNumber, pageSize, ct));
    }

   public  async Task<ApiResult<FamilyMemberDto?>> GetFamilyMemberByIdAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetFamilyMemberByIdAsync(id, ct));
    }

   public  async Task<ApiResult<FamilyEventDto?>> GetFamilyEventByIdAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetFamilyEventByIdAsync(id, ct));
    }

   public  async Task<ApiResult<PaginatedList<FamilyEventSummaryDto>>> GetFamilyEventsAsync(FamilyEventType? eventType, int pageNumber, int pageSize, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetFamilyEventsAsync(eventType, pageNumber, pageSize, ct));
    }

   public  async Task<ApiResult<FamilyRelationDto?>> GetFamilyRelationByIdAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetFamilyRelationByIdAsync(id, ct));
    }

   public  async Task<ApiResult<PaginatedList<FamilyRelationDto>?>> GetFamilyRelationsAsync(string? name, int pageNumber, int pageSize, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetFamilyRelationsAsync(name, pageNumber, pageSize, ct));
    }


   public  async Task<ApiResult<MessageResponse>> UpdateFamilyMemberAsync(string id, UpdateFamilyMemberRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.UpdateFamilyMemberAsync(id, request, ct));
    }

   public  async Task<ApiResult<MessageResponse>> UpdateFamilyEventAsync(string id, UpdateFamilyEventRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.UpdateFamilyEventAsync(id, request, ct));
    }

   public  async Task<ApiResult<MessageResponse>> UpdateFamilyRelationAsync(string id, UpdateFamilyRelationRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.UpdateFamilyRelationAsync(id, request, ct));
    }

    public async Task<ApiResult<List<SelectListItemDto>>> GetSelectListFamilyEventsAsync(string familyMemberId, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetSelectListFamilyEventsAsync(familyMemberId, ct));
    }

    public async Task<ApiResult<List<SelectListItemDto>>> GetSelectListFamilyRelationsAsync(CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetSelectListFamilyRelationsAsync(ct));
    }
}