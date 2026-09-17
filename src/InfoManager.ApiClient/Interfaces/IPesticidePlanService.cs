namespace InfoManager.ApiClient.Interfaces;

public interface IPesticidePlanService
{
    Task<ApiResult<PesticidePlanDto?>> GetPesticidePlanByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdatePesticidePlanAsync(string id, UpdatePesticidePlanRequest request, CancellationToken ct = default);

    Task<ApiResult> DeletePesticidePlanAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PesticidePlanSummaryDto>>> GetPesticidePlansAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreatePesticidePlanAsync(CreatePesticidePlanRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PesticidePlanSummaryDto>>> SearchPesticidePlansAsync(SearchPesticidePlansRequest request, CancellationToken ct = default);
}
