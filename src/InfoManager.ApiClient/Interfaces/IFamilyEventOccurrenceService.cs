using InfoManager.Shared.Dtos.FamilyEventOccurrences;

namespace InfoManager.ApiClient.Interfaces;

public interface IFamilyEventOccurrenceService
{
    Task<ApiResult<FamilyEventOccurrenceDto?>> GetFamilyEventOccurrenceByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFamilyEventOccurrenceAsync(string id, UpdateFamilyEventOccurrenceRequest dto, CancellationToken ct = default);

    Task<ApiResult> DeleteFamilyEventOccurrenceAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FamilyEventOccurrenceSummaryDto>>> GetFamilyEventOccurrencesByMemberIdAsync(string memberId, int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FamilyEventOccurrenceSummaryDto>>> GetFamilyEventOccurrencesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFamilyEventOccurrenceAsync(CreateFamilyEventOccurrenceRequest dto, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FamilyEventOccurrenceSummaryDto>>> SearchFamilyEventOccurrencesAsync(string searchTerm, int pageNumber, int pageSize, CancellationToken ct = default);
}