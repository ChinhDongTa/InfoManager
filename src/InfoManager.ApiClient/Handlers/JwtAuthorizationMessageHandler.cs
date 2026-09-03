using InfoManager.ApiClient.Abstractions;
using System.Net;
using System.Net.Http.Headers;

namespace InfoManager.ApiClient.Handlers;

public sealed class JwtAuthorizationMessageHandler(ITokenStorage tokenProvider, IAuthApi authApi) : DelegatingHandler
{
    private static readonly SemaphoreSlim _refreshLock = new(1, 1);

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = await tokenProvider.GetAccessTokenAsync();
        var path = request.RequestUri?.AbsolutePath ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await base.SendAsync(request, cancellationToken);
        //Console.WriteLine($"[Handler] Response: {(int)response.StatusCode} {path}");

        if (response.StatusCode != HttpStatusCode.Unauthorized)
            return response;

        // Bỏ qua các endpoint auth
        if (path.Contains("/refresh") || path.Contains("/login") || path.Contains("/register"))
            return response;

        await _refreshLock.WaitAsync(cancellationToken);
        try
        {
            // Kiểm tra xem token đã được refresh bởi request khác chưa
            var latestAccessToken = await tokenProvider.GetAccessTokenAsync();
            if (!string.IsNullOrWhiteSpace(latestAccessToken) && latestAccessToken != accessToken)
            {
                var cloned = await CloneRequestAsync(request);
                cloned.Headers.Authorization = new AuthenticationHeaderValue("Bearer", latestAccessToken);
                return await base.SendAsync(cloned, cancellationToken);
            }

            var refreshToken = await tokenProvider.GetRefreshTokenAsync();
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                await tokenProvider.ClearTokensAsync();
                return response;
            }

            // Gọi refresh bằng Refit interface (sạch hơn)
            var refreshResponse = await authApi.RefreshTokenAsync(new Shared.Dtos.Auths.RefreshRequest(refreshToken), cancellationToken);

            if (string.IsNullOrWhiteSpace(refreshResponse?.Content?.AccessToken))
            {
                await tokenProvider.ClearTokensAsync();
                return response;
            }

            // Lưu token mới
            await tokenProvider.SaveTokensAsync(refreshResponse.Content.AccessToken, refreshResponse.Content.RefreshToken);

            // Retry request gốc với token mới
            var retryRequest = await CloneRequestAsync(request);
            retryRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", refreshResponse.Content.AccessToken);
            return await base.SendAsync(retryRequest, cancellationToken);
        }
        finally
        {
            _refreshLock.Release();
        }
    }

    //private async Task HandleRefreshFailure()
    //{
    //    await tokenProvider.ClearTokensAsync();
    //    //navigationManager.NavigateTo("/Auth/login", forceLoad: true);
    //}

    private static async Task<HttpRequestMessage> CloneRequestAsync(HttpRequestMessage request)
    {
        var clone = new HttpRequestMessage(request.Method, request.RequestUri)
        {
            Version = request.Version
        };

        if (request.Content != null)
        {
            var bytes = await request.Content.ReadAsByteArrayAsync();
            clone.Content = new ByteArrayContent(bytes);
            foreach (var header in request.Content.Headers)
                clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        foreach (var header in request.Headers)
            clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

        return clone;
    }
}
