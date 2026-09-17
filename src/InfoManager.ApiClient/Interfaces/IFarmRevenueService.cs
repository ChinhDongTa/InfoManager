namespace InfoManager.ApiClient.Interfaces;

public interface IFarmRevenueService
{
    Task<ApiResult<FarmRevenueDto?>> GetFarmRevenueByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFarmRevenueAsync(string id, UpdateFarmRevenueRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFarmRevenueAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FarmRevenueSummaryDto>>> GetFarmRevenuesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFarmRevenueAsync(CreateFarmRevenueRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FarmRevenueSummaryDto>>> SearchFarmRevenuesAsync(SearchFarmRevenuesRequest request, CancellationToken ct = default);
}
