namespace InfoManager.ApiClient.Interfaces;

public interface IFertilizerApplicationService
{
    Task<ApiResult<FertilizerApplicationDto?>> GetFertilizerApplicationByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateFertilizerApplicationAsync(string id, UpdateFertilizerApplicationRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteFertilizerApplicationAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FertilizerApplicationSummaryDto>>> GetFertilizerApplicationsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateFertilizerApplicationAsync(CreateFertilizerApplicationRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<FertilizerApplicationSummaryDto>>> SearchFertilizerApplicationsAsync(SearchFertilizerApplicationsRequest request, CancellationToken ct = default);
}
