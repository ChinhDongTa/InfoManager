using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Services;

public class FieldService(IFieldApi api) : IFieldService
{
    public async Task<ApiResult<string>> CreateFieldAsync(CreateFieldRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync( await api.CreateFieldAsync(request, ct));

    public async Task<ApiResult> DeleteFieldAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteFieldAsync(id, ct));

    public async Task<ApiResult<FieldDto?>> GetFieldByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetFieldByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FieldSummaryDto>>> GetFieldsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetFieldsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FieldSummaryDto>>> SearchFieldsAsync(SearchFieldsRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchFieldsAsync(request.Term,
                                                                        request.FarmId,
                                                                        request.SoilCondition,
                                                                        request.Status,
                                                                        request.StartLastPreparationDate,
                                                                        request.EndLastPreparationDate,
                                                                        request.HasIrrigation,
                                                                        request.PageNumber,
                                                                        request.PageSize,
                                                                        ct));

    public async Task<ApiResult> UpdateFieldAsync(string id, UpdateFieldRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateFieldAsync(id, request, ct));
}
