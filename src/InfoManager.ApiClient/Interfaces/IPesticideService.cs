namespace InfoManager.ApiClient.Interfaces;

public interface IPesticideService
{
    Task<ApiResult<PesticideDto?>> GetPesticideByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdatePesticideAsync(string id, UpdatePesticideRequest request, CancellationToken ct = default);

    Task<ApiResult> DeletePesticideAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PesticideSummaryDto>>> GetPesticidesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreatePesticideAsync(CreatePesticideRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PesticideSummaryDto>>> SearchPesticidesAsync(SearchPesticidesRequest request, CancellationToken ct = default);
}
