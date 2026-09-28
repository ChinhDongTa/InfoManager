using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ApiClient.Services;

public class YieldService(IYieldApi api) : IYieldService
{
    public async Task<ApiResult<string>> CreateYieldAsync(CreateYieldRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateYieldAsync(request, ct));

    public async Task<ApiResult> DeleteYieldAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteYieldAsync(id, ct));

    public async Task<ApiResult<YieldDto?>> GetYieldByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetYieldByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<YieldSummaryDto>>> GetYieldsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetYieldsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<YieldSummaryDto>>> SearchYieldsAsync(SearchYieldsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchYieldsAsync(request.Term,
                                                                             request.CropPlantingId,
                                                                             request.HarvestId,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateYieldAsync(string id, UpdateYieldRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateYieldAsync(id, request, ct));
}
