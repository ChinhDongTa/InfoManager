namespace InfoManager.Domain.Entities.SFMS.HR;

// ======================== WorkShift ========================
/// <summary>
/// Ca làm việc
/// </summary>
public class WorkShift : BaseAuditableEntity
{
    /// <summary>Tên ca (Ca sáng, Ca chiều, Ca đêm...)</summary>
    [MaxLength(50)]
    public string Name { get; set; }

    /// <summary>Giờ bắt đầu</summary>
    public TimeOnly StartTime { get; set; }

    /// <summary>Giờ kết thúc</summary>
    public TimeOnly EndTime { get; set; }

    /// <summary>ID nông trại</summary>
    public string FarmId { get; set; }

    // Navigation
    public virtual Farm? Farm { get; set; }

    public virtual ICollection<EmployeeAttendance> Attendances { get; set; } = [];
}