namespace InfoManager.ApiClient.Interfaces;

public interface IJobPositionService
{
    Task<ApiResult<JobPositionDto?>> GetJobPositionByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateJobPositionAsync(string id, UpdateJobPositionRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteJobPositionAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<JobPositionSummaryDto>>> GetJobPositionsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateJobPositionAsync(CreateJobPositionRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<JobPositionSummaryDto>>> SearchJobPositionsAsync(SearchJobPositionsRequest request, CancellationToken ct = default);
}
