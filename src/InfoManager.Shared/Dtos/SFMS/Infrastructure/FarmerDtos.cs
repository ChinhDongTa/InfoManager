namespace InfoManager.Shared.Dtos.SFMS.Infrastructure;

/// <summary>
/// Chi tiết hồ sơ chủ hộ / chủ trang trại
/// </summary>
public record FarmerDto(
    string Id,

    /// <summary>Mã chủ hộ</summary>
    string? FarmerCode,
    /// <summary>Họ tên</summary>
    string FullName,
    string? FamilyMemberId,
    /// <summary>Số điện thoại</summary>
    string? Phone,

    /// <summary>Email liên hệ nghiệp vụ</summary>
    string? Email,

    /// <summary>CCCD / CMND</summary>
    string? IdentityNumber,

    /// <summary>Địa chỉ</summary>
    string? Address,

    /// <summary>Ghi chú</summary>
    string? Notes,

    DateTimeOffset Created
);

/// <summary>
/// Hồ sơ chủ hộ dùng cho danh sách
/// </summary>
public record FarmerSummaryDto(
    string Id,

    /// <summary>Mã chủ hộ</summary>
    string? FarmerCode,

    /// <summary>Họ tên</summary>
    string FullName,

    /// <summary>Số điện thoại</summary>
    string? Phone,

    /// <summary>Email</summary>
    string? Email
);

/// <summary>
/// Request tạo hồ sơ chủ hộ
/// </summary>
public record CreateFarmerRequest(
    /// <summary>ID tài khoản đăng nhập. Bắt buộc. Unique: 1 User tối đa 1 Farmer.</summary>
    string UserId,

    /// <summary>Họ tên. Bắt buộc, tối đa 200 ký tự.</summary>
    string FullName,

    /// <summary>ID thành viên gia đình.</summary>
    string? FamilyMemberId,

    /// <summary>Mã chủ hộ. Tối đa 50 ký tự. Để trống thì server tự sinh.</summary>
    string? FarmerCode,

    /// <summary>Số điện thoại. Tối đa 20 ký tự.</summary>
    string? Phone,

    /// <summary>Email. Tối đa 200 ký tự, đúng định dạng email.</summary>
    string? Email,

    /// <summary>CCCD / CMND. Tối đa 50 ký tự.</summary>
    string? IdentityNumber,

    /// <summary>Địa chỉ. Tối đa 500 ký tự.</summary>
    string? Address,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes
);

/// <summary>
/// Request cập nhật hồ sơ chủ hộ. Field null = không đổi.
/// </summary>
public record UpdateFarmerRequest(
    /// <summary>ID hồ sơ. Bắt buộc.</summary>
    string Id,

    /// <summary>ID thành viên gia đình.</summary>
    string? FamilyMemberId,

    /// <summary>Mã chủ hộ. Tối đa 50 ký tự.</summary>
    string? FarmerCode,

    /// <summary>Họ tên. Tối đa 200 ký tự.</summary>
    string? FullName,

    /// <summary>Số điện thoại. Tối đa 20 ký tự.</summary>
    string? Phone,

    /// <summary>Email. Tối đa 200 ký tự.</summary>
    string? Email,

    /// <summary>CCCD / CMND. Tối đa 50 ký tự.</summary>
    string? IdentityNumber,

    /// <summary>Địa chỉ. Tối đa 500 ký tự.</summary>
    string? Address,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes
);