using InfoManager.ApiClient.Abstractions;
using Microsoft.JSInterop;

namespace InfoManager.Web.Services;

public class TokenStorage(IJSRuntime js) : ITokenStorage
{
    private const string AccessTokenKey = "InfoManager_access_token";
    private const string RefreshTokenKey = "InfoManager_refresh_token";

    public async Task ClearTokensAsync(string? reason = null)
    {
        await js.InvokeVoidAsync("localStorage.removeItem", AccessTokenKey);
        await js.InvokeVoidAsync("localStorage.removeItem", RefreshTokenKey);
    }

    public async Task<string?> GetAccessTokenAsync()
        => await js.InvokeAsync<string?>("localStorage.getItem", AccessTokenKey);

    public async Task<string?> GetRefreshTokenAsync()
        => await js.InvokeAsync<string?>("localStorage.getItem", RefreshTokenKey);

    public async Task SaveTokensAsync(string accessToken, string? refreshToken)
    {
        if (string.IsNullOrWhiteSpace(accessToken))
        {
            await js.InvokeVoidAsync("localStorage.removeItem", AccessTokenKey);
        }
        else
        {
            await js.InvokeVoidAsync("localStorage.setItem", AccessTokenKey, accessToken);
        }

        if (string.IsNullOrWhiteSpace(refreshToken))
        {
            await js.InvokeVoidAsync("localStorage.removeItem", RefreshTokenKey);
        }
        else
        {
            await js.InvokeVoidAsync("localStorage.setItem", RefreshTokenKey, refreshToken);
        }
    }
}