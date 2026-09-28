using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ApiClient.Services;

public class HarvestService(IHarvestApi api) : IHarvestService
{
    public async Task<ApiResult<string>> CreateHarvestAsync(CreateHarvestRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateHarvestAsync(request, ct));

    public async Task<ApiResult> DeleteHarvestAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteHarvestAsync(id, ct));

    public async Task<ApiResult<HarvestDto?>> GetHarvestByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetHarvestByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<HarvestSummaryDto>>> GetHarvestsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetHarvestsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<HarvestSummaryDto>>> SearchHarvestsAsync(SearchHarvestsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchHarvestsAsync(request.Term,
                                                                             request.CropPlantingId,
                                                                             request.QualityGrade,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateHarvestAsync(string id, UpdateHarvestRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateHarvestAsync(id, request, ct));
}
