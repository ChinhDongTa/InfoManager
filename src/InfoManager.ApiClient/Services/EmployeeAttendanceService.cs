namespace InfoManager.ApiClient.Services;

internal class EmployeeAttendanceService(IEmployeeAttendanceApi api) : IEmployeeAttendanceService
{
    public async Task<ApiResult<string>> CreateEmployeeAttendanceAsync(CreateEmployeeAttendanceRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateEmployeeAttendanceAsync(request, ct));

    public async Task<ApiResult> DeleteEmployeeAttendanceAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteEmployeeAttendanceAsync(id, ct));

    public async Task<ApiResult<EmployeeAttendanceDto?>> GetEmployeeAttendanceByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetEmployeeAttendanceByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<EmployeeAttendanceSummaryDto>>> GetEmployeeAttendancesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetEmployeeAttendancesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<EmployeeAttendanceSummaryDto>>> SearchEmployeeAttendancesAsync(SearchEmployeeAttendancesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchEmployeeAttendancesAsync(request.Term,
                                                                             request.HREmployeeId,
                                                                             request.WorkShiftId,
                                                                             request.Status,
                                                                             request.AttendanceDate,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateEmployeeAttendanceAsync(string id, UpdateEmployeeAttendanceRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateEmployeeAttendanceAsync(id, request, ct));
}
