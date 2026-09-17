using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.ApiClient.Api;

internal interface IIntentionApi
{
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Intentions")]
    Task<ApiResponse<PaginatedList<IntentionSummaryDto>>> GetIntentionsAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Intentions")]
    Task<ApiResponse<string>> CreateIntentionAsync([Body] CreateIntentionRequest request, CancellationToken ct);

    /// <param name="top">top parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Intentions/top/{top}")]
    Task<ApiResponse<List<IntentionSummaryDto>>> GetTopIntentionsAsync(int top, CancellationToken ct);

    /// <param name="searchTerm">searchTerm parameter</param>
    /// <param name="categoryId">categoryId parameter</param>
    /// <param name="startDate">startDate parameter</param>
    /// <param name="endDate">endDate parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Intentions/search")]
    Task<ApiResponse<PaginatedList<IntentionSummaryDto>>> SearchIntentionsAsync([Query, AliasAs("SearchTerm")] string? searchTerm,
                                                                                [Query, AliasAs("CategoryId")] string? categoryId,
                                                                                [Query, AliasAs("StartDate")] System.DateTimeOffset? startDate,
                                                                                [Query, AliasAs("EndDate")] System.DateTimeOffset? endDate,
                                                                                [Query, AliasAs("PageNumber")] int pageNumber,
                                                                                [Query, AliasAs("PageSize")] int pageSize,
                                                                                CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Intentions/{id}")]
    Task<ApiResponse<IntentionDto?>> GetIntentionByIdAsync(string id, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/Intentions/{id}")]
    Task<IApiResponse> UpdateIntentionAsync(string id, [Body] UpdateIntentionRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/Intentions/{id}")]
    Task<IApiResponse> DeleteIntentionAsync(string id, CancellationToken ct);
}