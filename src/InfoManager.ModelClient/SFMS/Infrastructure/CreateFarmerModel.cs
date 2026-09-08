namespace InfoManager.ModelClient.SFMS.Infrastructure;

public class CreateFarmerModel
{
    /// <summary>
    /// Tài khoản đăng nhập của chủ hộ.
    /// 1 User chỉ có tối đa 1 hồ sơ Farmer.
    /// </summary>
    [Required]
    public string UserId { get; set; }=string.Empty;

    /// <summary>
    /// Liên kết thành viên gia đình nếu có.
    /// </summary>
    public string? FamilyMemberId { get; set; }

    /// <summary>
    /// Mã chủ hộ / mã nông dân
    /// </summary>
    [MaxLength(50)]
    public string? FarmerCode { get; set; }

    /// <summary>
    /// Họ tên chủ hộ
    /// </summary>
    [MaxLength(200)]
    [Required]
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Số điện thoại
    /// </summary>
    [MaxLength(20)]
    public string? Phone { get; set; }

    /// <summary>
    /// Email liên hệ nghiệp vụ
    /// </summary>
    [MaxLength(200)]
    public string? Email { get; set; }

    /// <summary>
    /// CCCD / CMND
    /// </summary>
    [MaxLength(50)]
    public string? IdentityNumber { get; set; }

    /// <summary>
    /// Địa chỉ thường trú / liên hệ
    /// </summary>
    [MaxLength(500)]
    public string? Address { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public CreateFarmerRequest CreateRequest()
    {
        return new CreateFarmerRequest
        (
            UserId : this.UserId,
            FullName: this.FullName,
            FamilyMemberId : this.FamilyMemberId,
            FarmerCode : this.FarmerCode,
            Phone : this.Phone,
            Email : this.Email,
            IdentityNumber : this.IdentityNumber,
            Address : this.Address,
            Notes : this.Notes
        );
    }
}