namespace InfoManager.ApiClient.Interfaces;

public interface IInfestationService
{
    Task<ApiResult<InfestationDto?>> GetInfestationByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateInfestationAsync(string id, UpdateInfestationRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteInfestationAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<InfestationSummaryDto>>> GetInfestationsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateInfestationAsync(CreateInfestationRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<InfestationSummaryDto>>> SearchInfestationsAsync(SearchInfestationsRequest request, CancellationToken ct = default);
}
