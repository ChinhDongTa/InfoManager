using InfoManager.ApiClient.Abstractions;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InfoManager.Web.Services;

/// <summary>
/// Quan lý trạng thái xác thực của người dùng trong ứng dụng Blazor. Sử dụng ITokenStorage để lưu trữ và truy xuất token.
/// </summary>
/// <param name="tokenStorage"></param>
public sealed class CustomAuthStateProvider(ITokenStorage tokenStorage) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await tokenStorage.GetAccessTokenAsync();

        // DEBUG
        if (string.IsNullOrWhiteSpace(token))
        {
            var cp = new ClaimsPrincipal(new ClaimsIdentity());
            return new AuthenticationState(cp);
        }
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            // check exp
            var expClaim = jwt.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;
            if (expClaim is not null && long.TryParse(expClaim, out var unixExp))
            {
                var expire = DateTimeOffset.FromUnixTimeSeconds(unixExp);
                if (expire < DateTimeOffset.UtcNow)
                {
                    await tokenStorage.ClearTokensAsync();
                    var anon = new ClaimsPrincipal(new ClaimsIdentity());
                    return new AuthenticationState(anon);
                }
            }

            var claims = jwt.Claims;
            var identity = new ClaimsIdentity(claims, "Bearer");
            var user = new ClaimsPrincipal(identity);

            //Console.WriteLine($"[GetAuthenticationStateAsync] User authenticated: {user.Identity?.Name}");
            return new AuthenticationState(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GetAuthenticationStateAsync] Error: {ex.Message}");
            var anon = new ClaimsPrincipal(new ClaimsIdentity());
            return new AuthenticationState(anon);
        }
    }

    /// <summary>
    /// Cập nhật trạng thái user sau khi đăng nhập thành công.
    /// Lưu token vào localStorage trước, rồi mới notify state change.
    /// </summary>
    public async Task MarkUserAsAuthenticatedAsync(string accessToken, string? refreshToken = null)
    {
        // Lưu token vào localStorage
        await tokenStorage.SaveTokensAsync(accessToken, refreshToken ?? await tokenStorage.GetRefreshTokenAsync());
        // Notify state change
        var authState = await GetAuthenticationStateAsync();
        NotifyAuthenticationStateChanged(Task.FromResult(authState));
    }

    /// <summary>
    /// Cập nhật trạng thái khi user đăng xuất.
    /// </summary>
    public async Task MarkUserAsLoggedOutAsync()
    {
        await tokenStorage.ClearTokensAsync(    );
        var anon = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anon)));
    }
}