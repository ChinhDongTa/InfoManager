namespace InfoManager.ApiClient.Interfaces;

public interface IHREmployeeService
{
    Task<ApiResult<HREmployeeDto?>> GetHREmployeeByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateHREmployeeAsync(string id, UpdateHREmployeeRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteHREmployeeAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<HREmployeeSummaryDto>>> GetHREmployeesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateHREmployeeAsync(CreateHREmployeeRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<HREmployeeSummaryDto>>> SearchHREmployeesAsync(SearchHREmployeesRequest request, CancellationToken ct = default);
}
