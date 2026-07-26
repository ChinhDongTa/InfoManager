using InfoManager.Shared.Dtos.Experiences;

namespace InfoManager.ApiClient.Interfaces;

public interface IExperienceService
{
    Task<ApiResult<ExperienceDto?>> GetExperienceByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> UpdateExperienceAsync(string id, UpdateExperienceRequest request, CancellationToken ct = default);
    Task<ApiResult<MessageResponse>> DeleteExperienceAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<ExperienceSummaryDto>>> GetExperiencesAsync(int     pageNumber=1, int pageSize=20, CancellationToken ct = default);
    Task<ApiResult<string>> CreateExperienceAsync(CreateExperienceRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<ExperienceSummaryDto>>> SearchExperiencesAsync(string? keyword, string? categoryId, int pageNumber=1, int pageSize=20, CancellationToken ct = default);
}
