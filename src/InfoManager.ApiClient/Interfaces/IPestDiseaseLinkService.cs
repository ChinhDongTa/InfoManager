namespace InfoManager.ApiClient.Interfaces;

public interface IPestDiseaseLinkService
{
    Task<ApiResult<PestDiseaseLinkDto?>> GetPestDiseaseLinkByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdatePestDiseaseLinkAsync(string id, UpdatePestDiseaseLinkRequest request, CancellationToken ct = default);

    Task<ApiResult> DeletePestDiseaseLinkAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PestDiseaseLinkSummaryDto>>> GetPestDiseaseLinksAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreatePestDiseaseLinkAsync(CreatePestDiseaseLinkRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<PestDiseaseLinkSummaryDto>>> SearchPestDiseaseLinksAsync(SearchPestDiseaseLinksRequest request, CancellationToken ct = default);
}
