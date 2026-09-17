namespace InfoManager.ApiClient.Interfaces;

public interface IEmployeeAttendanceService
{
    Task<ApiResult<EmployeeAttendanceDto?>> GetEmployeeAttendanceByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateEmployeeAttendanceAsync(string id, UpdateEmployeeAttendanceRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteEmployeeAttendanceAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<EmployeeAttendanceSummaryDto>>> GetEmployeeAttendancesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateEmployeeAttendanceAsync(CreateEmployeeAttendanceRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<EmployeeAttendanceSummaryDto>>> SearchEmployeeAttendancesAsync(SearchEmployeeAttendancesRequest request, CancellationToken ct = default);
}
