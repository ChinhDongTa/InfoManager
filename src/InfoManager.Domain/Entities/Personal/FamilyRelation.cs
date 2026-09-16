namespace InfoManager.Domain.Entities.Personal;

/// <summary>
/// Danh mục mối quan hệ gia đình (FamilyRelation-like)
/// </summary>
public class FamilyRelation : BaseAuditableEntity
{
    [MaxLength(100)]
    public string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<FamilyMember> FamilyMembers { get; set; } = [];
}