namespace InfoManager.ApiClient.Interfaces;

public interface IWorkShiftService
{
    Task<ApiResult<WorkShiftDto?>> GetWorkShiftByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateWorkShiftAsync(string id, UpdateWorkShiftRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteWorkShiftAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<WorkShiftSummaryDto>>> GetWorkShiftsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateWorkShiftAsync(CreateWorkShiftRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<WorkShiftSummaryDto>>> SearchWorkShiftsAsync(SearchWorkShiftsRequest request, CancellationToken ct = default);
}
