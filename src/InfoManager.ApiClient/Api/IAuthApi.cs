using InfoManager.Shared.Dtos.Auths;
namespace InfoManager.ApiClient.Api;

public interface IAuthApi
{
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Identities/login")]
    Task<ApiResponse<LoginResponse?>> LoginWithAsync([Body] LoginRequest request, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Identities/register")]
    Task<ApiResponse<MessageResponse>> RegisterAsync([Body] RegisterRequest request, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Identities/refresh")]
    Task<ApiResponse<TokenResponse?>> RefreshTokenAsync([Body] RefreshRequest request, CancellationToken ct = default);
}
