namespace InfoManager.ApiClient.Interfaces;

public interface ILeaveRequestService
{
    Task<ApiResult<LeaveRequestDto?>> GetLeaveRequestByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateLeaveRequestAsync(string id, UpdateLeaveRequestRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteLeaveRequestAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<LeaveRequestSummaryDto>>> GetLeaveRequestsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateLeaveRequestAsync(CreateLeaveRequestRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<LeaveRequestSummaryDto>>> SearchLeaveRequestsAsync(SearchLeaveRequestsRequest request, CancellationToken ct = default);
}
