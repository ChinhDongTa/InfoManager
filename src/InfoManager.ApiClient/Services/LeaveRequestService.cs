namespace InfoManager.ApiClient.Services;

internal class LeaveRequestService(ILeaveRequestApi api) : ILeaveRequestService
{
    public async Task<ApiResult<string>> CreateLeaveRequestAsync(CreateLeaveRequestRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateLeaveRequestAsync(request, ct));

    public async Task<ApiResult> DeleteLeaveRequestAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteLeaveRequestAsync(id, ct));

    public async Task<ApiResult<LeaveRequestDto?>> GetLeaveRequestByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetLeaveRequestByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<LeaveRequestSummaryDto>>> GetLeaveRequestsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetLeaveRequestsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<LeaveRequestSummaryDto>>> SearchLeaveRequestsAsync(SearchLeaveRequestsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchLeaveRequestsAsync(request.Term,
                                                                             request.HREmployeeId,
                                                                             request.Status,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateLeaveRequestAsync(string id, UpdateLeaveRequestRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateLeaveRequestAsync(id, request, ct));
}
