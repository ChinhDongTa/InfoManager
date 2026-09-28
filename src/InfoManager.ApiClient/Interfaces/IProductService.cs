using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ApiClient.Interfaces;

public interface IProductService
{
    Task<ApiResult<ProductDto?>> GetProductByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateProductAsync(string id, UpdateProductRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteProductAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<ProductSummaryDto>>> GetProductsAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateProductAsync(CreateProductRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<ProductSummaryDto>>> SearchProductsAsync(SearchProductsRequest request, CancellationToken ct = default);
}
