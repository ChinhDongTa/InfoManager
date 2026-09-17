namespace InfoManager.ApiClient.Services;

internal class HREmployeeService(IHREmployeeApi api) : IHREmployeeService
{
    public async Task<ApiResult<string>> CreateHREmployeeAsync(CreateHREmployeeRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateHREmployeeAsync(request, ct));

    public async Task<ApiResult> DeleteHREmployeeAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteHREmployeeAsync(id, ct));

    public async Task<ApiResult<HREmployeeDto?>> GetHREmployeeByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetHREmployeeByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<HREmployeeSummaryDto>>> GetHREmployeesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetHREmployeesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<HREmployeeSummaryDto>>> SearchHREmployeesAsync(SearchHREmployeesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchHREmployeesAsync(request.Term,
                                                                             request.FarmId,
                                                                             request.DepartmentId,
                                                                             request.Status,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateHREmployeeAsync(string id, UpdateHREmployeeRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateHREmployeeAsync(id, request, ct));
}
