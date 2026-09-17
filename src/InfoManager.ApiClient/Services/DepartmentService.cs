namespace InfoManager.ApiClient.Services;

internal class DepartmentService(IDepartmentApi api) : IDepartmentService
{
    public async Task<ApiResult<string>> CreateDepartmentAsync(CreateDepartmentRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateDepartmentAsync(request, ct));

    public async Task<ApiResult> DeleteDepartmentAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteDepartmentAsync(id, ct));

    public async Task<ApiResult<DepartmentDto?>> GetDepartmentByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetDepartmentByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<DepartmentSummaryDto>>> GetDepartmentsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetDepartmentsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<DepartmentSummaryDto>>> SearchDepartmentsAsync(SearchDepartmentsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchDepartmentsAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.ParentId,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateDepartmentAsync(string id, UpdateDepartmentRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateDepartmentAsync(id, request, ct));
}
