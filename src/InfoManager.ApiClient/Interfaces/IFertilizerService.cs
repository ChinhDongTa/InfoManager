namespace InfoManager.ApiClient.Interfaces;

public interface IFertilizerService
{
    Task<ApiResult<FertilizerDto?>> GetFertilizerByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFertilizerAsync(string id, UpdateFertilizerRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFertilizerAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FertilizerSummaryDto>>> GetFertilizersAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFertilizerAsync(CreateFertilizerRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FertilizerSummaryDto>>> SearchFertilizersAsync(SearchFertilizersRequest request, CancellationToken ct = default);
}
