using InfoManager.Shared.Dtos.FamilyEventOccurrences;

namespace InfoManager.ApiClient.Services;

public class FamilyEventOccurrenceService(IFamilyEventOccurrenceApi api ) : IFamilyEventOccurrenceService
{
    public async Task<ApiResult<string>> CreateFamilyEventOccurrenceAsync(CreateFamilyEventOccurrenceRequest dto, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.CreateFamilyEventOccurrenceAsync(dto, ct));

    public async Task<ApiResult> DeleteFamilyEventOccurrenceAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.DeleteFamilyEventOccurrenceAsync(id, ct));    

    public async Task<ApiResult<FamilyEventOccurrenceDto?>> GetFamilyEventOccurrenceByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyEventOccurrenceByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FamilyEventOccurrenceSummaryDto>>> GetFamilyEventOccurrencesByMemberIdAsync(string memberId,
                                                                                                                          int pageNumber,
                                                                                                                          int pageSize,
                                                                                                                          CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyEventOccurrenceByMemberIdAsync(memberId, pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FamilyEventOccurrenceSummaryDto>>> GetFamilyEventOccurrencesAsync(int pageNumber,
                                                                                                                int pageSize,
                                                                                                                CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyEventOccurrencesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FamilyEventOccurrenceSummaryDto>>> SearchFamilyEventOccurrencesAsync(string searchTerm,
                                                                                                                   int pageNumber,
                                                                                                                   int pageSize,
                                                                                                                   CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.SearchFamilyEventOccurrencesAsync(searchTerm, pageNumber, pageSize, ct));

    public async Task<ApiResult> UpdateFamilyEventOccurrenceAsync(string id, UpdateFamilyEventOccurrenceRequest dto, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.UpdateFamilyEventOccurrenceAsync(id, dto, ct));
}
