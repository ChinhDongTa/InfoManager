using InfoManager.Shared.Dtos.Categories;

namespace InfoManager.ApiClient.Services;

public class CategoryService(ICategoryApi api) : ICategoryService
{
    public async Task<ApiResult<string>> CreateCategoryAsync(CreateCategoryRequest request, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.CreateCategoryAsync(request, ct));

    public async Task<ApiResult> DeleteCategoryAsync(string id, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.DeleteCategoryAsync(id, ct));

    public async Task<ApiResult<PaginatedList<CategoryDto>>> GetCategoriesAsync(string? group,
                                                                                 string? keyname,
                                                                                 int pageNumber = 1,
                                                                                 int pageSize = 20,
                                                                                 CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.GetCategoriesAsync(group, keyname, pageNumber, pageSize, ct));

    public  async Task<ApiResult<CategoryDto?>> GetCategoryByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetCategoryByIdAsync(id, ct));

    public async Task<ApiResult<List<SelectListItemDto>>> GetSelectListCategoriesAsync(CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetSelectListCategoriesAsync(ct));

    public  async Task<ApiResult> UpdateCategoryAsync(string id, UpdateCategoryRequest request, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.UpdateCategoryAsync(id, request, ct));
}