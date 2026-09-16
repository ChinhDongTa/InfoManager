using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Interfaces;

public interface IFarmService
{
    Task<ApiResult<FarmDto?>> GetFarmByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFarmAsync(string id, UpdateFarmRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFarmAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FarmSummaryDto>>> GetFarmsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFarmAsync(CreateFarmRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FarmSummaryDto>>> SearchFarmsAsync(SearchFarmsRequest request, CancellationToken ct = default);
}