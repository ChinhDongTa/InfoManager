namespace InfoManager.Shared.Dtos.UserProfiles;

public record UserProfileDto(string Id, string UserId, string? FamilyMemberName, string? FamilyId, string? Notes, string? ImageUrl);
public record CreateUserProfileRequest(string UserId, string? FamilyMemberId, string? FamilyId, string? Notes, string? ImageUrl);
public record UpdateUserProfileRequest(string Id, string? FamilyMemberId, string? FamilyId, string? Notes, string? ImageUrl);