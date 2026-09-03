namespace InfoManager.Domain.Entities.SFMS.HR;

// ======================== JobAssignment ========================
/// <summary>
/// Phân công công việc
/// </summary>
public class JobAssignment : BaseAuditableEntity
{
    /// <summary>ID nhân viên</summary>
    public required string HREmployeeId { get; set; }

    /// <summary>ID vị trí công việc</summary>
    public required string JobPositionId { get; set; }

    /// <summary>Ngày bắt đầu</summary>
    public DateTimeOffset StartDate { get; set; }

    /// <summary>Ngày kết thúc</summary>
    public DateTimeOffset? EndDate { get; set; }

    /// <summary>Trạng thái phân công</summary>
    public AssignmentStatus Status { get; set; } = AssignmentStatus.Active;

    /// <summary>Mức lương được gán</summary>
    public decimal? AssignedSalary { get; set; }

    /// <summary>ID khu vực/đồng ruộng được phân công</summary>
    public string? AssignedFieldId { get; set; }

    /// <summary>ID người giám sát</summary>
    public string? SupervisorId { get; set; }

    /// <summary>Ghi chú hiệu suất</summary>
    [MaxLength(500)]
    public string? PerformanceNotes { get; set; }

    /// <summary>Lý do / mô tả phân công</summary>
    [MaxLength(500)]
    public string? AssignmentReason { get; set; }

    // Navigation
    public virtual HREmployee? HREmployee { get; set; }
    public virtual JobPosition? JobPosition { get; set; }
    public virtual Field? AssignedField { get; set; }
    public virtual HREmployee? Supervisor { get; set; }
}
