namespace InfoManager.ApiClient.Services;

public class SelectListService(ISelectListApi api) : ISelectListService
{
    public async Task<ApiResult<IEnumerable<SelectListItemDto>>> GetEnumSelectListAsync(string enumName, CancellationToken ct = default) 
        => await ApiResponseHandler.HandleAsync(await api.GetEnumValues(enumName, ct));
}
