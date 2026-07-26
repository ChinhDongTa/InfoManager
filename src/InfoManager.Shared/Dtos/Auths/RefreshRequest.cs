namespace InfoManager.Shared.Dtos.Auths;
public record RefreshRequest(string RefreshToken);
public record RegisterRequest(string Email, string Password);
public record RoleActionDto(string UserId, string Role);
public record CreateRoleDto(string Name);
public record RoleDto(string Id, string Name);
