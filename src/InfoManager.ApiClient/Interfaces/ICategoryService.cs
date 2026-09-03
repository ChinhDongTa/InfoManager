using InfoManager.Shared.Dtos.Categories;

namespace InfoManager.ApiClient.Interfaces;

public interface ICategoryService
{
    Task<ApiResult<PaginatedList<CategoryDto>>> GetCategoriesAsync(string? group, string? keyname, int pageNumber = 1, int pageSize = 20, CancellationToken ct = default);
    Task<ApiResult<CategoryDto?>> GetCategoryByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<List<SelectListItemDto>>> GetSelectListCategoriesAsync(CancellationToken ct = default);
    Task<ApiResult<string>> CreateCategoryAsync(CreateCategoryRequest request, CancellationToken ct = default);
    Task<ApiResult> UpdateCategoryAsync(string id, UpdateCategoryRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteCategoryAsync(string id, CancellationToken ct = default);
}
