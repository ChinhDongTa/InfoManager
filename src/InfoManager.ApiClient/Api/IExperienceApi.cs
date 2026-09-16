using InfoManager.Shared.Dtos.Experiences;

namespace InfoManager.ApiClient.Api;

public interface IExperienceApi
{
    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Experiences/{id}")]
    Task<ApiResponse<ExperienceDto?>> GetExperienceByIdAsync(string id, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/Experiences/{id}")]
    Task<IApiResponse> UpdateExperienceAsync(string id, [Body] UpdateExperienceRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/Experiences/{id}")]
    Task<IApiResponse> DeleteExperienceAsync(string id, CancellationToken ct);

    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Experiences")]
    Task<ApiResponse<PaginatedList<ExperienceSummaryDto>>> GetExperiencesAsync([Query, AliasAs("PageNumber")] int pageNumber, [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Experiences")]
    Task<ApiResponse<string>> CreateExperienceAsync([Body] CreateExperienceRequest request, CancellationToken ct);

    /// <param name="keyword">keyword parameter</param>
    /// <param name="categoryId">categoryId parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Experiences/search")]
    Task<ApiResponse<PaginatedList<ExperienceSummaryDto>>> SearchExperiencesAsync([Query, AliasAs("Keyword")] string? keyword,
                                                                      [Query, AliasAs("CategoryId")] string? categoryId,
                                                                      [Query, AliasAs("PageNumber")] int? pageNumber,
                                                                      [Query, AliasAs("PageSize")] int? pageSize, CancellationToken ct);
}