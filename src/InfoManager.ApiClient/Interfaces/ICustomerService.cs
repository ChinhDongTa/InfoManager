using InfoManager.Shared.Dtos.SFMS.Customers;

namespace InfoManager.ApiClient.Interfaces;

public interface ICustomerService
{
    //========================================Customer Care========================================
    Task<ApiResult<CustomerCareDto?>> GetCustomerCareByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateCustomerCareAsync(string id, UpdateCustomerCareRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteCustomerCareAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CustomerCareSummaryDto>>> GetCustomerCaresAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateCustomerCareAsync(CreateCustomerCareRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CustomerCareSummaryDto>>> SearchCustomerCaresAsync(SearchCustomerCareRequest request, CancellationToken ct = default);

    //========================================Customer Payment========================================
    Task<ApiResult<CustomerPaymentDto?>> GetCustomerPaymentByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateCustomerPaymentAsync(string id, UpdateCustomerPaymentRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteCustomerPaymentAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CustomerPaymentSummaryDto>>> GetCustomerPaymentsAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateCustomerPaymentAsync(CreateCustomerPaymentRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CustomerPaymentSummaryDto>>> SearchCustomerPaymentsAsync(SearchCustomerPaymentRequest request, CancellationToken ct = default);

    //========================================Customer========================================
    Task<ApiResult<CustomerDto?>> GetCustomerByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateCustomerAsync(string id, UpdateCustomerRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteCustomerAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CustomerSummaryDto>>> GetCustomersAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateCustomerAsync([Body] CreateCustomerRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CustomerSummaryDto>>> SearchCustomersAsync(SearchCustomerRequest request, CancellationToken ct = default);
}