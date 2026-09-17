namespace InfoManager.ApiClient.Interfaces;

public interface IDepartmentService
{
    Task<ApiResult<DepartmentDto?>> GetDepartmentByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateDepartmentAsync(string id, UpdateDepartmentRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteDepartmentAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<DepartmentSummaryDto>>> GetDepartmentsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateDepartmentAsync(CreateDepartmentRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<DepartmentSummaryDto>>> SearchDepartmentsAsync(SearchDepartmentsRequest request, CancellationToken ct = default);
}
