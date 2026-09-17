using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Services;

internal class EquipmentService(IEquipmentApi api) : IEquipmentService
{
    public async Task<ApiResult<string>> CreateEquipmentAsync(CreateEquipmentRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.CreateEquipmentAsync(request, ct));

    public async Task<ApiResult> DeleteEquipmentAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteEquipmentAsync(id, ct));

    public async Task<ApiResult<EquipmentDto?>> GetEquipmentByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetEquipmentByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<EquipmentSummaryDto>>> GetEquipmentsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetEquipmentsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<EquipmentSummaryDto>>> SearchEquipmentsAsync(SearchEquipmentsRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchEquipmentsAsync(request.Term,
                                                                           request.EquipmentType,
                                                                           request.FarmId,
                                                                           request.Status,
                                                                           request.LastMaintenanceDateFrom,
                                                                           request.LastMaintenanceDateTo,
                                                                           request.NextMaintenanceDateFrom,
                                                                           request.NextMaintenanceDateTo,
                                                                           request.PageNumber,
                                                                           request.PageSize,
                                                                           ct));

    public async Task<ApiResult> UpdateEquipmentAsync(string id, UpdateEquipmentRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateEquipmentAsync(id, request, ct));
}