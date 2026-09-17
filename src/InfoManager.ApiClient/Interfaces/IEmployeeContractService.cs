namespace InfoManager.ApiClient.Interfaces;

public interface IEmployeeContractService
{
    Task<ApiResult<EmployeeContractDto?>> GetEmployeeContractByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateEmployeeContractAsync(string id, UpdateEmployeeContractRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteEmployeeContractAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<EmployeeContractSummaryDto>>> GetEmployeeContractsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateEmployeeContractAsync(CreateEmployeeContractRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<EmployeeContractSummaryDto>>> SearchEmployeeContractsAsync(SearchEmployeeContractsRequest request, CancellationToken ct = default);
}
