using InfoManager.Shared.Dtos.Categories;


namespace InfoManager.ApiClient.Api;

public interface ICategoryApi
{
    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Categories/{id}")]
    Task<ApiResponse<CategoryDto?>> GetCategoryByIdAsync(string id, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/Categories/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateCategoryAsync(string id, [Body] UpdateCategoryRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/Categories/{id}")]
    Task<ApiResponse<MessageResponse>> DeleteCategoryAsync(string id, CancellationToken ct);

    /// <param name="group">group parameter</param>
    /// <param name="keyname">keyname parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Categories")]
    Task<ApiResponse<PaginatedList<CategoryDto>>> GetCategoriesAsync([Query] string? group,
                                                                     [Query] string? keyname,
                                                                     [Query] int pageNumber ,
                                                                     [Query] int pageSize,
                                                                     CancellationToken ct = default);
    /// <summary>
    /// Get a list of categories for select list
    /// </summary>
    /// <param name="ct">A token to cancel the operation.</param>
    /// <returns>Http 200 OK if the categories are found.</returns>
    [Get("/api/Categories/select-list")]
    Task<ApiResponse<List<SelectListItemDto>>> GetSelectListCategoriesAsync(CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Categories")]
    Task<ApiResponse<string>> CreateCategoryAsync([Body] CreateCategoryRequest request ,CancellationToken ct  );
}
