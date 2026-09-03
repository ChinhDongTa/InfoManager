using InfoManager.Shared.Dtos.UserProfiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoManager.ApiClient.Interfaces;

public interface IUserProfileService
{
    Task<ApiResult<UserProfileDto?>> GetUserProfileByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<UserProfileDto>>> GetUserProfilesAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateUserProfileAsync(CreateUserProfileRequest request, CancellationToken ct = default);
    Task<ApiResult> UpdateUserProfileAsync(string id, UpdateUserProfileRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteUserProfileAsync(string id, CancellationToken ct = default);
}
