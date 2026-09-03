using InfoManager.Domain.Entities.SFMS.HR;

/// <summary>
/// Cấu hình Entity Framework cho Department
/// </summary>
public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(500);

        builder.Property(d => d.FarmId)
            .IsRequired();

        // Navigation: Department -> Parent (Self-referencing)
        builder.HasOne(d => d.Parent)
            .WithMany(d => d.Children)
            .HasForeignKey(d => d.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Navigation: Department -> Farm
        builder.HasOne(d => d.Farm)
            .WithMany()
            .HasForeignKey(d => d.FarmId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(d => d.FarmId);
        builder.HasIndex(d => d.ParentId);
        builder.HasIndex(d => d.Name);
    }
}

/// <summary>
/// Cấu hình Entity Framework cho JobPosition
/// </summary>
public class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition>
{
    public void Configure(EntityTypeBuilder<JobPosition> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);

        builder.Property(p => p.RequiredQualifications)
            .HasMaxLength(500);

        builder.Property(p => p.Notes)
            .HasMaxLength(500);

        // Navigation: JobPosition -> Department
        builder.HasOne(p => p.Department)
            .WithMany(d => d.JobPositions)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

        // Indexes
        builder.HasIndex(p => p.DepartmentId);
        builder.HasIndex(p => p.Title);
        builder.HasIndex(p => p.IsActive);
    }
}

/// <summary>
/// Cấu hình Entity Framework cho HREmployee
/// </summary>
public class HREmployeeConfiguration : IEntityTypeConfiguration<HREmployee>
{
    public void Configure(EntityTypeBuilder<HREmployee> builder)
    {
        builder.ToTable("HREmployees");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FarmId)
            .IsRequired()
            .HasMaxLength(450);

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasMaxLength(450);

        builder.Property(x => x.FamilyMemberId).HasMaxLength(450);
        builder.Property(x => x.DepartmentId).HasMaxLength(450);
        builder.Property(x => x.EmployeeNumber).HasMaxLength(50);
        builder.Property(x => x.TerminationReason).HasMaxLength(500);
        builder.Property(x => x.BankAccount).HasMaxLength(50);
        builder.Property(x => x.EmergencyContactName).HasMaxLength(200);
        builder.Property(x => x.EmergencyContactPhone).HasMaxLength(20);
        builder.Property(x => x.Notes).HasMaxLength(500);

        builder.Property(x => x.Salary).HasPrecision(18, 2);
        builder.Property(x => x.Status).HasConversion<int>();
        builder.Property(x => x.SalaryType).HasConversion<int>();

        builder.HasIndex(x => x.FarmId);
        builder.HasIndex(x => x.UserId).IsUnique();
        builder.HasIndex(x => x.EmployeeNumber).IsUnique();
        builder.HasIndex(x => new { x.FarmId, x.EmployeeNumber });

        builder.HasOne(x => x.Farm)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.FarmId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.FamilyMember)
            .WithMany()
            .HasForeignKey(x => x.FamilyMemberId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Department)
            .WithMany()
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

/// <summary>
/// Cấu hình Entity Framework cho JobAssignment
/// </summary>
public class JobAssignmentConfiguration : IEntityTypeConfiguration<JobAssignment>
{
    public void Configure(EntityTypeBuilder<JobAssignment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.HREmployeeId)
            .IsRequired();

        builder.Property(a => a.JobPositionId)
            .IsRequired();

        builder.Property(a => a.PerformanceNotes)
            .HasMaxLength(500);

        builder.Property(a => a.AssignmentReason)
            .HasMaxLength(500);

        // Navigation: JobAssignment -> HREmployee
        builder.HasOne(a => a.HREmployee)
            .WithMany(e => e.JobAssignments)
            .HasForeignKey(a => a.HREmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Navigation: JobAssignment -> JobPosition
        builder.HasOne(a => a.JobPosition)
            .WithMany(p => p.Assignments)
            .HasForeignKey(a => a.JobPositionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Navigation: JobAssignment -> Field
        builder.HasOne(a => a.AssignedField)
            .WithMany()
            .HasForeignKey(a => a.AssignedFieldId)
            .OnDelete(DeleteBehavior.SetNull);

        // Navigation: JobAssignment -> Supervisor (HREmployee)
        builder.HasOne(a => a.Supervisor)
            .WithMany()
            .HasForeignKey(a => a.SupervisorId)
            .OnDelete(DeleteBehavior.SetNull);

        // Indexes
        builder.HasIndex(a => a.HREmployeeId);
        builder.HasIndex(a => a.JobPositionId);
        builder.HasIndex(a => a.Status);
        builder.HasIndex(a => a.StartDate);
        builder.HasIndex(a => a.AssignedFieldId);
    }
}

/// <summary>
/// Cấu hình Entity Framework cho EmployeeAttendance
/// </summary>
public class EmployeeAttendanceConfiguration : IEntityTypeConfiguration<EmployeeAttendance>
{
    public void Configure(EntityTypeBuilder<EmployeeAttendance> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.HREmployeeId)
            .IsRequired();

        builder.Property(a => a.Reason)
            .HasMaxLength(500);

        builder.Property(a => a.Notes)
            .HasMaxLength(500);

        // Navigation: EmployeeAttendance -> HREmployee
        builder.HasOne(a => a.HREmployee)
            .WithMany(e => e.Attendances)
            .HasForeignKey(a => a.HREmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Navigation: EmployeeAttendance -> WorkShift
        builder.HasOne(a => a.WorkShift)
            .WithMany(s => s.Attendances)
            .HasForeignKey(a => a.WorkShiftId)
            .OnDelete(DeleteBehavior.SetNull);

        // Indexes
        builder.HasIndex(a => a.HREmployeeId);
        builder.HasIndex(a => a.AttendanceDate);
        builder.HasIndex(a => new { a.HREmployeeId, a.AttendanceDate }).IsUnique();
        builder.HasIndex(a => a.Status);
        builder.HasIndex(a => a.WorkShiftId);
    }
}

/// <summary>
/// Cấu hình Entity Framework cho WorkShift
/// </summary>
public class WorkShiftConfiguration : IEntityTypeConfiguration<WorkShift>
{
    public void Configure(EntityTypeBuilder<WorkShift> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.FarmId)
            .IsRequired();

        // Navigation: WorkShift -> Farm
        builder.HasOne(s => s.Farm)
            .WithMany()
            .HasForeignKey(s => s.FarmId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(s => s.FarmId);
        builder.HasIndex(s => s.Name);
    }
}

/// <summary>
/// Cấu hình Entity Framework cho LeaveRequest
/// </summary>
public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.HREmployeeId)
            .IsRequired();

        builder.Property(l => l.LeaveType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(l => l.Reason)
            .HasMaxLength(500);

        builder.Property(l => l.Status)
            .IsRequired()
            .HasMaxLength(20);

        // Navigation: LeaveRequest -> HREmployee
        builder.HasOne(l => l.HREmployee)
            .WithMany(e => e.LeaveRequests)
            .HasForeignKey(l => l.HREmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(l => l.HREmployeeId);
        builder.HasIndex(l => l.Status);
        builder.HasIndex(l => l.FromDate);
        builder.HasIndex(l => l.ToDate);
    }
}

/// <summary>
/// Cấu hình Entity Framework cho EmployeeContract
/// </summary>
public class EmployeeContractConfiguration : IEntityTypeConfiguration<EmployeeContract>
{
    public void Configure(EntityTypeBuilder<EmployeeContract> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.HREmployeeId)
            .IsRequired();

        builder.Property(c => c.ContractNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.ContractType)
            .IsRequired()
            .HasMaxLength(50);

        // Navigation: EmployeeContract -> HREmployee
        builder.HasOne(c => c.HREmployee)
            .WithMany(e => e.Contracts)
            .HasForeignKey(c => c.HREmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(c => c.HREmployeeId);
        builder.HasIndex(c => c.ContractNumber).IsUnique();
        builder.HasIndex(c => c.IsActive);
        builder.HasIndex(c => c.StartDate);
    }
}

/// <summary>
/// Cấu hình Entity Framework cho Payroll
/// </summary>
public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
{
    public void Configure(EntityTypeBuilder<Payroll> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.HREmployeeId)
            .IsRequired();

        builder.Property(p => p.DeductionDetails)
            .HasMaxLength(1000);

        builder.Property(p => p.PaymentMethod)
            .HasMaxLength(50);

        builder.Property(p => p.ReferenceNumber)
            .HasMaxLength(100);

        builder.Property(p => p.Notes)
            .HasMaxLength(500);

        // Navigation: Payroll -> HREmployee
        builder.HasOne(p => p.HREmployee)
            .WithMany(e => e.PayrollRecords)
            .HasForeignKey(p => p.HREmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(p => p.HREmployeeId);
        builder.HasIndex(p => p.PeriodStartDate);
        builder.HasIndex(p => p.PeriodEndDate);
        builder.HasIndex(p => p.PaymentStatus);
        builder.HasIndex(p => new { p.HREmployeeId, p.PeriodStartDate, p.PeriodEndDate });
    }
}