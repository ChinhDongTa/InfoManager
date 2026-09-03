namespace InfoManager.Domain.Entities.Personal;

/// <summary>
/// Danh mục mối quan hệ gia đình (FamilyRelation-like)
/// </summary>
public class FamilyRelation: BaseAuditableEntity
{
    [MaxLength(100)]
    /// <summary>
    /// Tên mối quan hệ (Ông cố nội, Bà cố nội, Ông cố ngoại, Bà cố ngoại, Ông nội, Bà nội, Ông ngoại, Bà ngoại, Cha, Mẹ, Con trai, Con gái)
    /// </summary>
    public required string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<FamilyMember> FamilyMembers { get; set; } = [];
}