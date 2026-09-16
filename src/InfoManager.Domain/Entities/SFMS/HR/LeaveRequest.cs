namespace InfoManager.Domain.Entities.SFMS.HR;

// ======================== LeaveRequest ========================
/// <summary>
/// Đơn xin nghỉ phép
/// </summary>
public class LeaveRequest : BaseAuditableEntity
{
    /// <summary>ID nhân viên</summary>
    public string HREmployeeId { get; set; }

    /// <summary>Loại nghỉ (Phép năm, Ốm, Việc riêng...)</summary>
    [MaxLength(50)]
    public string LeaveType { get; set; }

    /// <summary>Ngày bắt đầu</summary>
    public DateOnly FromDate { get; set; }

    /// <summary>Ngày kết thúc</summary>
    public DateOnly ToDate { get; set; }

    /// <summary>Lý do</summary>
    [MaxLength(500)]
    public string? Reason { get; set; }

    /// <summary>Trạng thái (Pending, Approved, Rejected)</summary>
    [MaxLength(20)]
    public string Status { get; set; } = "Pending";

    /// <summary>Người duyệt</summary>
    public string? ApprovedBy { get; set; }

    /// <summary>Thời điểm duyệt</summary>
    public DateTimeOffset? ApprovedAt { get; set; }

    // Navigation
    public virtual HREmployee? HREmployee { get; set; }
}