using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Services;

internal class FarmerService(IFarmerApi api) : IFarmerService
{
    public async Task<ApiResult<string>> CreateFarmerAsync(CreateFarmerRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.CreateFarmerAsync(request, ct));

    public async Task<ApiResult> DeleteFarmerAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteFarmerAsync(id, ct));

    public async Task<ApiResult<FarmerDto?>> GetFarmerByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetFarmerByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FarmerSummaryDto>>> GetFarmersAsync(int pageNumber, int pageSize, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetFarmersAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FarmerSummaryDto>>> SearchFarmersAsync(SearchTermRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchFarmersAsync(request.Term, request.PageNumber, request.PageSize, ct));

    public async Task<ApiResult> UpdateFarmerAsync(string id, UpdateFarmerRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateFarmerAsync(id, request, ct));
}