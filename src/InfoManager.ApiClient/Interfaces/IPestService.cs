namespace InfoManager.ApiClient.Interfaces;

public interface IPestService
{
    Task<ApiResult<PestDto?>> GetPestByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdatePestAsync(string id, UpdatePestRequest request, CancellationToken ct = default);

    Task<ApiResult> DeletePestAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PestSummaryDto>>> GetPestsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreatePestAsync(CreatePestRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PestSummaryDto>>> SearchPestsAsync(SearchPestsRequest request, CancellationToken ct = default);
}
