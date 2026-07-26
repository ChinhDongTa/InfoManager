using InfoManager.Shared.Dtos.Experiences;

namespace InfoManager.ApiClient.Services;

public class ExperienceService(IExperienceApi api) : IExperienceService
{
    public  async Task<ApiResult<string>> CreateExperienceAsync(CreateExperienceRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.CreateExperienceAsync(request, ct));
    }

    public  async Task<ApiResult<MessageResponse>> DeleteExperienceAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.DeleteExperienceAsync(id, ct));
    }

    public  async Task<ApiResult<ExperienceDto?>> GetExperienceByIdAsync(string id, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetExperienceByIdAsync(id, ct));
    }

    public  async Task<ApiResult<PaginatedList<ExperienceSummaryDto>>> GetExperiencesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.GetExperiencesAsync(pageNumber, pageSize, ct));
    }

    public  async Task<ApiResult<PaginatedList<ExperienceSummaryDto>>> SearchExperiencesAsync(string? keyword, string? categoryId, int pageNumber, int pageSize, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.SearchExperiencesAsync(keyword, categoryId, pageNumber, pageSize, ct));
    }

    public  async Task<ApiResult<MessageResponse>> UpdateExperienceAsync(string id, UpdateExperienceRequest request, CancellationToken ct = default)
    {
        return await ApiResponseHandler.HandleAsync(await api.UpdateExperienceAsync(id, request, ct));
    }
}