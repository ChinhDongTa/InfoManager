namespace InfoManager.ApiClient.Interfaces;

public interface IDiseaseService
{
    Task<ApiResult<DiseaseDto?>> GetDiseaseByIdAsync(string id, CancellationToken ct = default);

    Task<ApiResult> UpdateDiseaseAsync(string id, UpdateDiseaseRequest request, CancellationToken ct = default);

    Task<ApiResult> DeleteDiseaseAsync(string id, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<DiseaseSummaryDto>>> GetDiseasesAsync(int pageNumber, int pageSize, CancellationToken ct = default);

    Task<ApiResult<string>> CreateDiseaseAsync(CreateDiseaseRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<DiseaseSummaryDto>>> SearchDiseasesAsync(SearchDiseasesRequest request, CancellationToken ct = default);
}
