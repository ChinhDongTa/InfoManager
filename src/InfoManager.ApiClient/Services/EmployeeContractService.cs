namespace InfoManager.ApiClient.Services;

internal class EmployeeContractService(IEmployeeContractApi api) : IEmployeeContractService
{
    public async Task<ApiResult<string>> CreateEmployeeContractAsync(CreateEmployeeContractRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateEmployeeContractAsync(request, ct));

    public async Task<ApiResult> DeleteEmployeeContractAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteEmployeeContractAsync(id, ct));

    public async Task<ApiResult<EmployeeContractDto?>> GetEmployeeContractByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetEmployeeContractByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<EmployeeContractSummaryDto>>> GetEmployeeContractsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetEmployeeContractsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<EmployeeContractSummaryDto>>> SearchEmployeeContractsAsync(SearchEmployeeContractsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchEmployeeContractsAsync(request.Term,
                                                                             request.HREmployeeId,
                                                                             request.ContractType,
                                                                             request.IsActive,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateEmployeeContractAsync(string id, UpdateEmployeeContractRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateEmployeeContractAsync(id, request, ct));
}
