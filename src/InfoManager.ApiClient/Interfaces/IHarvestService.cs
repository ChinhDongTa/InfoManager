using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ApiClient.Interfaces;

public interface IHarvestService
{
    Task<ApiResult<HarvestDto?>> GetHarvestByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateHarvestAsync(string id, UpdateHarvestRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteHarvestAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<HarvestSummaryDto>>> GetHarvestsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateHarvestAsync(CreateHarvestRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<HarvestSummaryDto>>> SearchHarvestsAsync(SearchHarvestsRequest request, CancellationToken ct = default);
}
