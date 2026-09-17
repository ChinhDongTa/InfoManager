namespace InfoManager.ApiClient.Services;

internal class JobAssignmentService(IJobAssignmentApi api) : IJobAssignmentService
{
    public async Task<ApiResult<string>> CreateJobAssignmentAsync(CreateJobAssignmentRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateJobAssignmentAsync(request, ct));

    public async Task<ApiResult> DeleteJobAssignmentAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteJobAssignmentAsync(id, ct));

    public async Task<ApiResult<JobAssignmentDto?>> GetJobAssignmentByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetJobAssignmentByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<JobAssignmentSummaryDto>>> GetJobAssignmentsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetJobAssignmentsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<JobAssignmentSummaryDto>>> SearchJobAssignmentsAsync(SearchJobAssignmentsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchJobAssignmentsAsync(request.Term,
                                                                             request.HREmployeeId,
                                                                             request.JobPositionId,
                                                                             request.Status,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateJobAssignmentAsync(string id, UpdateJobAssignmentRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateJobAssignmentAsync(id, request, ct));
}
