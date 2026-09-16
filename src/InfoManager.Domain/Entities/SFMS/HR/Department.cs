namespace InfoManager.Domain.Entities.SFMS.HR;

// ======================== Department ========================
/// <summary>
/// Phòng ban / Tổ / Đội trong nông trại
/// </summary>
public class Department : BaseAuditableEntity
{
    /// <summary>Tên phòng ban / tổ</summary>
    [MaxLength(100)]
    public string Name { get; set; }

    /// <summary>Mô tả</summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>ID phòng ban cấp trên (nếu có)</summary>
    public string? ParentId { get; set; }

    /// <summary>ID nông trại</summary>
    public string FarmId { get; set; }

    // Navigation
    public virtual Department? Parent { get; set; }

    public virtual ICollection<Department> Children { get; set; } = [];
    public virtual ICollection<JobPosition> JobPositions { get; set; } = [];
    public virtual ICollection<HREmployee> Employees { get; set; } = [];
    public virtual Farm? Farm { get; set; }
}