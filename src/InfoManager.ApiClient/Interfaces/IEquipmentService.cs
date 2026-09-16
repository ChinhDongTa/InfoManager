using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Interfaces;

public interface IEquipmentService
{
    Task<ApiResult<EquipmentDto?>> GetEquipmentByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateEquipmentAsync(string id, UpdateEquipmentRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteEquipmentAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<EquipmentSummaryDto>>> GetEquipmentsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateEquipmentAsync(CreateEquipmentRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<EquipmentSummaryDto>>> SearchEquipmentsAsync(SearchEquipmentsRequest request, CancellationToken ct = default);
}