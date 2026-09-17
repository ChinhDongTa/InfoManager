namespace InfoManager.ApiClient.Services;

internal class JobPositionService(IJobPositionApi api) : IJobPositionService
{
    public async Task<ApiResult<string>> CreateJobPositionAsync(CreateJobPositionRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateJobPositionAsync(request, ct));

    public async Task<ApiResult> DeleteJobPositionAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteJobPositionAsync(id, ct));

    public async Task<ApiResult<JobPositionDto?>> GetJobPositionByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetJobPositionByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<JobPositionSummaryDto>>> GetJobPositionsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetJobPositionsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<JobPositionSummaryDto>>> SearchJobPositionsAsync(SearchJobPositionsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchJobPositionsAsync(request.Term,
                                                                             request.DepartmentId,
                                                                             request.IsActive,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateJobPositionAsync(string id, UpdateJobPositionRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateJobPositionAsync(id, request, ct));
}
