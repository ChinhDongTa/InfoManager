using InfoManager.Domain.Entities.Authentication;
using InfoManager.Domain.Entities.Personal;
namespace InfoManager.Domain.Entities.SFMS.HR;

// ======================== HREmployee ========================
/// <summary>
/// Nhân viên nông trại (HR)
/// </summary>
public class HREmployee : BaseAuditableEntity
{
    /// <summary>ID thành viên gia đình liên kết (1-1, tùy chọn)</summary>
    public string? FamilyMemberId { get; set; }

    /// <summary>ID nông trại</summary>
    public required string FarmId { get; set; }

    /// <summary>UserId (liên kết tài khoản đăng nhập)</summary>
    public required string UserId { get; set; }

    /// <summary>ID phòng ban</summary>
    public string? DepartmentId { get; set; }

    /// <summary>Mã số nhân viên (duy nhất)</summary>
    [MaxLength(50)]
    public string? EmployeeNumber { get; set; }

    /// <summary>Trạng thái làm việc</summary>
    public EmploymentStatus Status { get; set; } = EmploymentStatus.Active;

    /// <summary>Ngày tuyển dụng</summary>
    public DateTimeOffset? HireDate { get; set; }

    /// <summary>Ngày chấm dứt hợp đồng</summary>
    public DateTimeOffset? TerminationDate { get; set; }

    /// <summary>Lý do chấm dứt</summary>
    [MaxLength(500)]
    public string? TerminationReason { get; set; }

    /// <summary>Mức lương hiện tại</summary>
    public decimal Salary { get; set; }

    /// <summary>Loại lương</summary>
    public SalaryType SalaryType { get; set; } = SalaryType.Monthly;

    /// <summary>Số tài khoản ngân hàng</summary>
    [MaxLength(50)]
    public string? BankAccount { get; set; }

    /// <summary>Tên người liên hệ khẩn cấp</summary>
    [MaxLength(200)]
    public string? EmergencyContactName { get; set; }

    /// <summary>Số điện thoại liên hệ khẩn cấp</summary>
    [MaxLength(20)]
    public string? EmergencyContactPhone { get; set; }

    /// <summary>Ghi chú</summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    // Navigation
    public virtual FamilyMember? FamilyMember { get; set; }
    public virtual Farm? Farm { get; set; }
    public virtual ApplicationUser? User { get; set; }
    public virtual Department? Department { get; set; }
    public virtual JobAssignment? CurrentJobAssignment { get; set; }
    public virtual ICollection<JobAssignment> JobAssignments { get; set; } = [];
    public virtual ICollection<EmployeeAttendance> Attendances { get; set; } = [];
    public virtual ICollection<Payroll> PayrollRecords { get; set; } = [];
    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = [];
    public virtual ICollection<EmployeeContract> Contracts { get; set; } = [];
    public virtual ICollection<WorkShift> WorkShifts { get; set; } = []; // nếu dùng many-to-many
}
