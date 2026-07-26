using InfoManager.Shared.Dtos.Auths;

namespace InfoManager.ApiClient.Api;

public interface IIdentityApi
{
    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Identities/users/{id}")]
    Task<ApiResponse<UserDto?>> GetUserByIdAsync(string id, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/Identities/users/{id}")]
    Task<ApiResponse<MessageResponse>> DeleteUserAsync(string id, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="dto">dto parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/Identities/users/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateUserAsync(string id, [Body] UpdateUserDto dto, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Identities/user-detail/{id}")]
    Task<ApiResponse<UserDetailDto?>> GetUserDetailsByIdAsync(string id, CancellationToken ct = default);

    /// <param name="email">email parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Identities/users/search/{email}")]
    Task<ApiResponse<List<UserDto?>>> SearchUserByEmailAsync(string email, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Identities/remove-from-role")]
    Task<ApiResponse<MessageResponse>> RemoveFromRoleAsync([Body] RoleActionDto request, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Identities/add-to-role")]
    Task<ApiResponse<MessageResponse>> AddToRoleAsync([Body] RoleActionDto request, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Identities/create-role")]
    Task<ApiResponse<string>> CreateRoleAsync([Body] CreateRoleDto request, CancellationToken ct = default);

    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Identities/roleNames")]
    Task<ApiResponse<List<string>>> GetRoleNamesAsync(CancellationToken ct = default);

    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Identities/roles")]
    Task<ApiResponse<List<RoleDto>>> GetRolesAsync(CancellationToken ct = default);
}