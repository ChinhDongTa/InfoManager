using InfoManager.Shared.Dtos.SFMS.Customers;

namespace InfoManager.ApiClient.Services;

internal class CustomerService(ICustomerApi api) : ICustomerService
{
    public async Task<ApiResult<string>> CreateCustomerAsync([Body] CreateCustomerRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateCustomerAsync(request, ct));

    public async Task<ApiResult<string>> CreateCustomerCareAsync(CreateCustomerCareRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateCustomerCareAsync(request, ct));

    public async Task<ApiResult<string>> CreateCustomerPaymentAsync(CreateCustomerPaymentRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateCustomerPaymentAsync(request, ct));

    public async Task<ApiResult> DeleteCustomerAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteCustomerAsync(id, ct));

    public async Task<ApiResult> DeleteCustomerCareAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteCustomerCareAsync(id, ct));

    public async Task<ApiResult> DeleteCustomerPaymentAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteCustomerPaymentAsync(id, ct));

    public async Task<ApiResult<CustomerDto?>> GetCustomerByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetCustomerByIdAsync(id, ct));

    public async Task<ApiResult<CustomerCareDto?>> GetCustomerCareByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetCustomerCareByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<CustomerCareSummaryDto>>> GetCustomerCaresAsync(int pageNumber, int pageSize, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetCustomerCaresAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<CustomerPaymentDto?>> GetCustomerPaymentByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetCustomerPaymentByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<CustomerPaymentSummaryDto>>> GetCustomerPaymentsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetCustomerPaymentsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<CustomerSummaryDto>>> GetCustomersAsync(int pageNumber, int pageSize, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetCustomersAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<CustomerCareSummaryDto>>> SearchCustomerCaresAsync(SearchCustomerCareRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchCustomerCaresAsync(request.Term,
                                                                               request.StartCareDate,
                                                                               request.EndCareDate,
                                                                               request.StartNextFollowUpDate,
                                                                               request.EndNextFollowUpDate,
                                                                               request.PageNumber,
                                                                               request.PageSize,
                                                                               ct));

    public async Task<ApiResult<PaginatedList<CustomerPaymentSummaryDto>>> SearchCustomerPaymentsAsync(SearchCustomerPaymentRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchCustomerPaymentsAsync(request.Term,
                                                                                   request.StartPaymentDate,
                                                                                   request.EndPaymentDate,
                                                                                   request.PageNumber,
                                                                                   request.PageSize,
                                                                                   ct));

    public async Task<ApiResult<PaginatedList<CustomerSummaryDto>>> SearchCustomersAsync(SearchCustomerRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchCustomersAsync(request.Term,
                                                                          request.CustomerType,
                                                                          request.MinCreditLimit,
                                                                          request.MaxCreditLimit,
                                                                          request.Status,
                                                                          request.PageNumber,
                                                                          request.PageSize,
                                                                          ct));

    public async Task<ApiResult> UpdateCustomerAsync(string id, UpdateCustomerRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateCustomerAsync(id, request, ct));

    public async Task<ApiResult> UpdateCustomerCareAsync(string id, UpdateCustomerCareRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateCustomerCareAsync(id, request, ct));

    public async Task<ApiResult> UpdateCustomerPaymentAsync(string id, UpdateCustomerPaymentRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateCustomerPaymentAsync(id, request, ct));
}