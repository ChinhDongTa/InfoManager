namespace InfoManager.ApiClient.Interfaces;

public interface ISelectListService
{
    Task<ApiResult<IEnumerable<SelectListItemDto>>> GetEnumSelectListAsync(string enumName, CancellationToken ct = default);
}