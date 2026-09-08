using InfoManager.Shared.Dtos.Common;
using InfoManager.Web.Models;
using System.Net.Http.Json;

namespace InfoManager.Web.Services;

public interface ISelectListService
{
    Task<List<SelectListItemDto>> GetAsync(string route, ApiClientKind clientKind);
}

public class SelectListService(IHttpClientFactory httpClientFactory) : ISelectListService
{
    public async Task<List<SelectListItemDto>> GetAsync(string route, ApiClientKind clientKind)
    {
        var client = CreateClient(clientKind);
        var response = await client.GetFromJsonAsync<List<SelectListItemDto>>(route);
        return response ?? [];
    }

    private HttpClient CreateClient(ApiClientKind clientKind)
    {
        return clientKind == ApiClientKind.Public
            ? httpClientFactory.CreateClient(Constants.PublicHttpClient)
            : httpClientFactory.CreateClient(Constants.ProtectHttpClient);
    }
}