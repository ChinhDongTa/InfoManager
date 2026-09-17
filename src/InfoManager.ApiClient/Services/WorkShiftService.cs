namespace InfoManager.ApiClient.Services;

internal class WorkShiftService(IWorkShiftApi api) : IWorkShiftService
{
    public async Task<ApiResult<string>> CreateWorkShiftAsync(CreateWorkShiftRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateWorkShiftAsync(request, ct));

    public async Task<ApiResult> DeleteWorkShiftAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteWorkShiftAsync(id, ct));

    public async Task<ApiResult<WorkShiftDto?>> GetWorkShiftByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetWorkShiftByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<WorkShiftSummaryDto>>> GetWorkShiftsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetWorkShiftsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<WorkShiftSummaryDto>>> SearchWorkShiftsAsync(SearchWorkShiftsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchWorkShiftsAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateWorkShiftAsync(string id, UpdateWorkShiftRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateWorkShiftAsync(id, request, ct));
}
