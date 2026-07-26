using InfoManager.Enum;
using InfoManager.Shared.Dtos.FamilyMembers;

namespace InfoManager.ModelClient.Families;

public class CreateFamilyMemberModel
{
    [MaxLength(200)]
    [Required]
    /// <summary>
    /// Tên thành viên gia đình
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Mối quan hệ với người dùng (Ông cố nội, Bà cố nội, Ông cố ngoại, Bà cố ngoại, Ông nội, Bà nội, Ông ngoại, Bà ngoại, Cha, Mẹ, Con trai, Con gái)
    /// </summary>

    public string? FamilyRelationId { get; set; }

    /// <summary>
    /// Ngày sinh của thành viên gia đình
    /// </summary>
    public DateOnly BirthDate { get; set; }
    /// <summary>
    /// Ngày mất của thành viên gia đình
    /// </summary>
    public DateOnly? DeathDate { get; set; }

    /// <summary>
    /// Giới tính của thành viên gia đình
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Địa chỉ email của thành viên gia đình
    /// </summary>
    [EmailAddress]
    [MaxLength(200)]
    public string? Email { get; set; }

    /// <summary>
    /// Số điện thoại của thành viên gia đình
    /// </summary>
    [MaxLength(50)]
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// Ghi chú về thành viên gia đình
    /// </summary>
    public string? Note { get; set; }

    public CreateFamilyMemberRequest CreateRequest()
    {
        return new CreateFamilyMemberRequest
        {
            FullName = this.FullName,
            FamilyRelationId = this.FamilyRelationId,
            BirthDate = this.BirthDate,
            DeathDate = this.DeathDate,
            Gender = this.Gender,
            Email = this.Email,
            PhoneNumber = this.PhoneNumber,
            Note = this.Note
        };
    }
}
