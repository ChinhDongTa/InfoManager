using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ApiClient.Services;

public class ProductService(IProductApi api) : IProductService
{
    public async Task<ApiResult<string>> CreateProductAsync(CreateProductRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateProductAsync(request, ct));

    public async Task<ApiResult> DeleteProductAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteProductAsync(id, ct));

    public async Task<ApiResult<ProductDto?>> GetProductByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetProductByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<ProductSummaryDto>>> GetProductsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetProductsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<ProductSummaryDto>>> SearchProductsAsync(SearchProductsRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchProductsAsync(request.Term,
                                                                             request.HarvestId,
                                                                             request.Status,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult> UpdateProductAsync(string id, UpdateProductRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateProductAsync(id, request, ct));
}
