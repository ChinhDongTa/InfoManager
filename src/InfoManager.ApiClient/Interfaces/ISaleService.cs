using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ApiClient.Interfaces;

public interface ISaleService
{
    Task<ApiResult<SaleDto?>> GetSaleByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateSaleAsync(string id, UpdateSaleRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteSaleAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<SaleSummaryDto>>> GetSalesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateSaleAsync(CreateSaleRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<SaleSummaryDto>>> SearchSalesAsync(SearchSalesRequest request, CancellationToken ct = default);
}
