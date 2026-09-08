using InfoManager.Shared.Dtos.SFMS.Infrastructure;

namespace InfoManager.ApiClient.Interfaces;

public interface IFieldService
{
    Task<ApiResult<FieldDto?>> GetFieldByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateFieldAsync(string id, UpdateFieldRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteFieldAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<FieldSummaryDto>>> GetFieldsAsync( int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateFieldAsync( CreateFieldRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<FieldSummaryDto>>> SearchFieldsAsync(SearchFieldsRequest request, CancellationToken ct = default);
}
