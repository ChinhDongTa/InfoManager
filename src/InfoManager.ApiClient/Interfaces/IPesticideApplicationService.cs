namespace InfoManager.ApiClient.Interfaces;

public interface IPesticideApplicationService
{
    Task<ApiResult<PesticideApplicationDto?>> GetPesticideApplicationByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdatePesticideApplicationAsync(string id, UpdatePesticideApplicationRequest request, CancellationToken ct = default);

    Task<ApiResult> DeletePesticideApplicationAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PesticideApplicationSummaryDto>>> GetPesticideApplicationsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreatePesticideApplicationAsync(CreatePesticideApplicationRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PesticideApplicationSummaryDto>>> SearchPesticideApplicationsAsync(SearchPesticideApplicationsRequest request, CancellationToken ct = default);
}
