namespace InfoManager.Domain.Entities.SFMS.HR;

// ======================== JobPosition ========================
/// <summary>
/// Vị trí / chức danh công việc trong nông trại
/// </summary>
public class JobPosition : BaseAuditableEntity
{
    /// <summary>Tên vị trí (vd: Quản lý nông trại, Công nhân đồng ruộng...)</summary>
    [MaxLength(100)]
    public string Title { get; set; }

    /// <summary>Mô tả / trách nhiệm</summary>
    [MaxLength(1000)]
    public string? Description { get; set; }

    /// <summary>Mức lương tối thiểu</summary>
    public decimal? MinSalary { get; set; }

    /// <summary>Mức lương tối đa</summary>
    public decimal? MaxSalary { get; set; }

    /// <summary>ID phòng ban</summary>
    public string? DepartmentId { get; set; }

    /// <summary>Yêu cầu trình độ / kỹ năng</summary>
    [MaxLength(500)]
    public string? RequiredQualifications { get; set; }

    /// <summary>Vị trí còn hoạt động / đang tuyển</summary>
    public bool IsActive { get; set; } = true;

    /// <summary>Số lượng vị trí cần tuyển</summary>
    public int? NumberOfPositions { get; set; }

    /// <summary>Ghi chú</summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation
    public virtual Department? Department { get; set; }

    public virtual ICollection<JobAssignment> Assignments { get; set; } = [];
}