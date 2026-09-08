using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Services;

public class FarmService(IFarmApi api) : IFarmService
{
    public async Task<ApiResult<string>> CreateFarmAsync(CreateFarmRequest request, CancellationToken ct = default)
    =>await ApiResponseHandler.HandleAsync(await api.CreateFarmAsync(request, ct));

    public async Task<ApiResult> DeleteFarmAsync(string id, CancellationToken ct = default)
    =>await ApiResponseHandler.HandleAsync(await api.DeleteFarmAsync(id, ct));

    public async Task<ApiResult<FarmDto?>> GetFarmByIdAsync(string id, CancellationToken ct = default)
    =>await ApiResponseHandler.HandleAsync(await api.GetFarmByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FarmSummaryDto>>> GetFarmsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
  =>  await ApiResponseHandler.HandleAsync(await api.GetFarmsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FarmSummaryDto>>> SearchFarmsAsync(SearchFarmsRequest request, CancellationToken ct = default)
    =>await ApiResponseHandler.HandleAsync(await api.SearchFarmsAsync(request.Term,
                                                                      request.MinCultivableArea,
                                                                      request.MaxCultivableArea,
                                                                      request.Status,
                                                                      request.PageNumber,
                                                                      request.PageSize,
                                                                      ct));

    public async Task<ApiResult> UpdateFarmAsync(string id, UpdateFarmRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateFarmAsync(id, request, ct));
}
