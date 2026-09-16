using InfoManager.Shared.Dtos.Auths;

namespace InfoManager.ApiClient.Interfaces;

public interface IAuthService
{
    Task<ApiResult<LoginResponse?>> LoginAsync(LoginRequest loginRequest, CancellationToken ct = default);

    Task<ApiResult<LoginResponse?>> RegisterAsync(RegisterRequest registerRequest, CancellationToken ct = default);

    Task<ApiResult<TokenResponse?>> RefreshTokenAsync(string refreshToken, CancellationToken ct = default);

    Task<ApiResult<MessageResponse>> LogoutAsync(LogoutRequest? request, CancellationToken ct = default);
}