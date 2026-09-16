using InfoManager.ApiClient.Api;
using InfoManager.ApiClient.Handlers;
using InfoManager.ApiClient.Interfaces;
using InfoManager.ApiClient.Models;
using InfoManager.Helper;
using InfoManager.Shared.Dtos.Auths;
using InfoManager.Shared.Dtos.Common;

namespace InfoManager.Web.Services;

public sealed class AuthService(IAuthApi authApi, IProtectAuthApi protectAuthApi, CustomAuthStateProvider authStateProvider) : IAuthService
{
    public async Task<ApiResult<LoginResponse?>> LoginAsync(LoginRequest loginRequest, CancellationToken ct = default)
    {
        var response = (await authApi.LoginWithAsync(loginRequest, ct));
        var result = await ApiResponseHandler.HandleAsync(response);
        if (result.Success && result.Data is not null)
        {
            await authStateProvider.MarkUserAsAuthenticatedAsync(result.Data.AccessToken, result.Data.RefreshToken);
        }
        return result;
    }

    public async Task<ApiResult<LoginResponse?>> RegisterAsync(RegisterRequest registerRequest, CancellationToken ct = default)
    {
        var response = await authApi.RegisterAsync(registerRequest, ct);
        var result = await ApiResponseHandler.HandleAsync(response);
        if (result.Success && result.Data is not null)
        {
            return await LoginAsync(new LoginRequest { Email = registerRequest.Email, Password = registerRequest.Password }, ct);
        }
        return ApiResult<LoginResponse?>.Fail([ErrorHelpers.GetErrorUnknown]);
    }

    public async Task<ApiResult<TokenResponse?>> RefreshTokenAsync(string refreshToken, CancellationToken ct = default)
    {
        var request = new RefreshRequest(RefreshToken: refreshToken);
        var response = await authApi.RefreshTokenAsync(request, ct);
        var result = await ApiResponseHandler.HandleAsync(response);
        if (result.Success && result.Data is not null)
        {
            await authStateProvider.MarkUserAsAuthenticatedAsync(result.Data.AccessToken, result.Data.RefreshToken);
        }
        return result;
    }

    public async Task<ApiResult<MessageResponse>> LogoutAsync(LogoutRequest? request, CancellationToken ct = default)
    {
        var response = await protectAuthApi.LogoutAsync(request, ct);
        var result = await ApiResponseHandler.HandleAsync(response);
        if (result.Success)
        {
            await authStateProvider.MarkUserAsLoggedOutAsync();
        }
        return result;
    }
}