using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ApiClient.Interfaces;

public interface IYieldService
{
    Task<ApiResult<YieldDto?>> GetYieldByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateYieldAsync(string id, UpdateYieldRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteYieldAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<YieldSummaryDto>>> GetYieldsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateYieldAsync(CreateYieldRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<YieldSummaryDto>>> SearchYieldsAsync(SearchYieldsRequest request, CancellationToken ct = default);
}
