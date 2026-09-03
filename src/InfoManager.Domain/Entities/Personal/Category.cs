namespace InfoManager.Domain.Entities.Personal;

/// <summary>
/// Danh mục trải nghiệm, ví dụ: "Du lịch", "Ẩm thực", "Giải trí", "Học tập", v.v.
/// </summary>
public class Category : BaseAuditableEntity
{
    [MaxLength(200)]
    /// <summary>
    /// Tên phân loại trải nghiệm
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Nhóm phân loại, ví dụ: "Kinh nghiệm", "Ý định", "Giao dịch"
    /// </summary>
    [MaxLength(50)]
    public string? Group { get; set; }
    /// <summary>
    /// Tên khóa phân loại group, ví dụ: "Kinh-Nghiem", "Y-Dinh", "Giao-Dich"
    /// </summary>
    [MaxLength (50)]
    public string? KeyName { get; set; }

    public ICollection<Experience> Experience { get; set; } = [];
    public ICollection<Intention> Intentions { get; set; } = [];
    public ICollection<Transaction> Transactions { get; set; } = [];
}