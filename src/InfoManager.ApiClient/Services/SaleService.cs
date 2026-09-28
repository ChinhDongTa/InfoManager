using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ApiClient.Services;

public class SaleService(ISaleApi api) : ISaleService
{
    public async Task<ApiResult<string>> CreateSaleAsync(CreateSaleRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateSaleAsync(request, ct));

    public async Task<ApiResult> DeleteSaleAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteSaleAsync(id, ct));

    public async Task<ApiResult<SaleDto?>> GetSaleByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetSaleByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<SaleSummaryDto>>> GetSalesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetSalesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<SaleSummaryDto>>> SearchSalesAsync(SearchSalesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchSalesAsync(request.Term,
                                                                             request.ProductId,
                                                                             request.PaymentStatus,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateSaleAsync(string id, UpdateSaleRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateSaleAsync(id, request, ct));
}
