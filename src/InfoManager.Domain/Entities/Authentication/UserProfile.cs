using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Domain.Entities.Authentication;

public class UserProfile : BaseAuditableEntity
{
    public string UserId { get; set; }               // FK → ApplicationUser (1-1)
    public ApplicationUser? User { get; set; }

    // === Liên kết Gia đình ===
    public string? FamilyMemberId { get; set; }

    public FamilyMember? FamilyMember { get; set; }

    public string? FamilyId { get; set; }                     // denormalized để lấy nhanh
    public Family? Family { get; set; }

    [MaxLength(200)]
    public string? Notes { get; set; }

    public string? ImageUrl { get; set; }

    // Sau này muốn thêm gì cứ thêm vào đây:
    // public string? Avatar { get; set; }
    // public string? PreferredLanguage { get; set; }
    // public bool IsFamilyAdmin { get; set; }
    // ...
}