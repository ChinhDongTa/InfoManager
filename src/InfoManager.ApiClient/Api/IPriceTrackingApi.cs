using InfoManager.Shared.Dtos.PriceTrackings;

namespace InfoManager.ApiClient.Api;

internal interface IPriceTrackingApi
{
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/PriceTrackings")]
    Task<ApiResponse<PaginatedList<PriceTrackingSummaryDto>>> GetPriceTrackingsAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/PriceTrackings")]
    Task<ApiResponse<string>> CreatePriceTrackingAsync([Body] CreatePriceTrackingRequest request, CancellationToken ct);

    /// <param name="top">top parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/PriceTrackings/top/{top}")]
    Task<ApiResponse<List<PriceTrackingSummaryDto>>> GetTopPriceTrackingsAsync(int top, CancellationToken ct);

    /// <param name="searchTerm">searchTerm parameter</param>
    /// <param name="minPrice">minPrice parameter</param>
    /// <param name="maxPrice">maxPrice parameter</param>
    /// <param name="sortBy">sortBy parameter</param>
    /// <param name="ascending">ascending parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/PriceTrackings/search")]
    Task<ApiResponse<PaginatedList<PriceTrackingSummaryDto>>> SearchPriceTrackingsAsync([Query, AliasAs("SearchTerm")] string? searchTerm,
                                                                                        [Query, AliasAs("MinPrice")] decimal? minPrice,
                                                                                        [Query, AliasAs("MaxPrice")] decimal? maxPrice,
                                                                                        [Query, AliasAs("SortBy")] string? sortBy,
                                                                                        [Query, AliasAs("Ascending")] bool? ascending,
                                                                                        [Query, AliasAs("PageNumber")] int pageNumber,
                                                                                        [Query, AliasAs("PageSize")] int pageSize,
                                                                                        CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/PriceTrackings/{id}")]
    Task<ApiResponse<PriceTrackingDto?>> GetPriceTrackingByIdAsync(string id, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/PriceTrackings/{id}")]
    Task<IApiResponse> UpdatePriceTrackingAsync(string id, [Body] UpdatePriceTrackingRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/PriceTrackings/{id}")]
    Task<IApiResponse> DeletePriceTrackingAsync(string id, CancellationToken ct);
}