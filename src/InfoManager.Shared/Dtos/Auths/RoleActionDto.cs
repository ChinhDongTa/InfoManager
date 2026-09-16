namespace InfoManager.Shared.Dtos.Auths;

/// <summary>
/// Thêm, xóa và xác nhận tồn tại của Role cho User
/// </summary>
/// <param name="UserId"></param>
/// <param name="Role"></param>
public record RoleActionDto(string UserId, string Role);