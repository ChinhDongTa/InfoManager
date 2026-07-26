using InfoManager.Shared.Dtos.Auths;
namespace InfoManager.ApiClient.Api;

public interface IProtectAuthApi
{
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Identities/logout")]
   Task<ApiResponse<MessageResponse>> LogoutAsync([Body] LogoutRequest? request, CancellationToken ct = default);
}