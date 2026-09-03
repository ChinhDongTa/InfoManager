namespace InfoManager.Domain.Entities.Personal;

/// <summary>
/// Thông tin về một gia đình, bao gồm tên, địa chỉ, email và các thành viên trong gia đình.
/// https://x.com/i/grok?conversation=2082011094034608189 đang trao đổi với grok.
/// Luồng xử lí tạo lần đầu: Thông tin cá nhân → Tạo User (FamilyAdmin) + UserProfile + FamilyMember + Family
/// </summary>
public class Family : BaseAuditableEntity
{
    [MaxLength(200)]
    public required string Name { get; set; }
    /// <summary>
    /// Người đại diện của gia đình, có thể là cha/mẹ hoặc con trưởng
    /// </summary>
    public string? RepresentativeId { get; set; }//=> có thể là foreign key tới FamilyMember không?
    public virtual FamilyMember? Representative { get; set; }   // Navigation
    public string? Address { get; set; }

    [EmailAddress]
    public string? Email { get; set; }
    // Navigation
    public ICollection<FamilyMember> Members { get; set; } = [];
}