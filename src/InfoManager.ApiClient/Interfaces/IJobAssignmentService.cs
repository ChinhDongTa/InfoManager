namespace InfoManager.ApiClient.Interfaces;

public interface IJobAssignmentService
{
    Task<ApiResult<JobAssignmentDto?>> GetJobAssignmentByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateJobAssignmentAsync(string id, UpdateJobAssignmentRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteJobAssignmentAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<JobAssignmentSummaryDto>>> GetJobAssignmentsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateJobAssignmentAsync(CreateJobAssignmentRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<JobAssignmentSummaryDto>>> SearchJobAssignmentsAsync(SearchJobAssignmentsRequest request, CancellationToken ct = default);
}
