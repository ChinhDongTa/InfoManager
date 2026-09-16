using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Interfaces;

public interface IFarmerService
{
    Task<ApiResult<FarmerDto?>> GetFarmerByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFarmerAsync(string id, UpdateFarmerRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFarmerAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FarmerSummaryDto>>> GetFarmersAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFarmerAsync(CreateFarmerRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FarmerSummaryDto>>> SearchFarmersAsync(SearchTermRequest request, CancellationToken ct = default);
}