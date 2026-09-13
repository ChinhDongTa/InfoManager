using InfoManager.Application.Features.SFMS.HR.Queries.Gets;
namespace InfoManager.Application.Features.SFMS.HR.Queries;

public static class QueryExtensions
{
    //======================================== Department ========================================

    public static IQueryable<DepartmentDto> ToDepartmentDto(this IQueryable<Department> query)
        => query.Select(d => new DepartmentDto(
            Id: d.Id,
            Name: d.Name,
            Description: d.Description,
            ParentId: d.ParentId,
            ParentName: d.Parent != null ? d.Parent.Name : null,
            FarmId: d.FarmId,
            FarmName: d.Farm != null ? d.Farm.Name : null,
            Created: d.Created
        ));

    public static IQueryable<DepartmentSummaryDto> ToDepartmentSummaryDto(this IQueryable<Department> query)
        => query.Select(d => new DepartmentSummaryDto(
            Id: d.Id,
            Name: d.Name,
            ParentName: d.Parent != null ? d.Parent.Name : null,
            EmployeeCount: d.Employees.Count(),
            JobPositionCount: d.JobPositions.Count()
        ));

    public static IQueryable<Department> BuildSearchQuery(this IQueryable<Department> query, SearchDepartmentsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(d => EF.Functions.ILike(d.Name, term)
                || (d.Description != null && EF.Functions.ILike(d.Description, term)));
        }
        if (!string.IsNullOrEmpty(search.FarmId))
            query = query.Where(d => d.FarmId == search.FarmId);
        if (!string.IsNullOrEmpty(search.ParentId))
            query = query.Where(d => d.ParentId == search.ParentId);
        return query;
    }

    /// <summary>sortBy: name</summary>
    public static IQueryable<Department> ApplySorting(this IQueryable<Department> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.Created).ThenBy(a => a.Name);
        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name),
            _ => query
        };
    }

    //======================================== HREmployee ========================================

    public static IQueryable<HREmployeeDto> ToHREmployeeDto(this IQueryable<HREmployee> query)
        => query.Select(e => new HREmployeeDto(
            Id: e.Id,
            FamilyMemberId: e.FamilyMemberId,
            FamilyMemberName: e.FamilyMember != null ? e.FamilyMember.FullName : null,
            FarmId: e.FarmId,
            FarmName: e.Farm != null ? e.Farm.Name : null,
            UserId: e.UserId,
            UserName: e.User != null ? e.User.UserName : null,
            FullName: e.FamilyMember != null ? e.FamilyMember.FullName : null,
            Email: e.FamilyMember != null ? e.FamilyMember.Email : (e.User != null ? e.User.Email : null),
            Phone: e.FamilyMember != null ? e.FamilyMember.PhoneNumber : null,
            DepartmentId: e.DepartmentId,
            DepartmentName: e.Department != null ? e.Department.Name : null,
            EmployeeNumber: e.EmployeeNumber,
            StatusName: e.Status.ToDisplayName(),
            HireDate: e.HireDate,
            TerminationDate: e.TerminationDate,
            TerminationReason: e.TerminationReason,
            Salary: e.Salary,
            SalaryTypeName: e.SalaryType.ToDisplayName(),
            BankAccount: e.BankAccount,
            EmergencyContactName: e.EmergencyContactName,
            EmergencyContactPhone: e.EmergencyContactPhone,
            Notes: e.Notes,
            CurrentJobAssignmentId: e.CurrentJobAssignment != null ? e.CurrentJobAssignment.Id : null,
            CurrentJobPositionTitle: e.CurrentJobAssignment != null && e.CurrentJobAssignment.JobPosition != null
                ? e.CurrentJobAssignment.JobPosition.Title : null,
            Created: e.Created
        ));

    public static IQueryable<HREmployeeSummaryDto> ToHREmployeeSummaryDto(this IQueryable<HREmployee> query)
        => query.Select(e => new HREmployeeSummaryDto(
            Id: e.Id,
            EmployeeNumber: e.EmployeeNumber,
            FullName: e.FamilyMember != null ? e.FamilyMember.FullName : null,
            DepartmentName: e.Department != null ? e.Department.Name : null,
            JobPositionTitle: e.CurrentJobAssignment != null && e.CurrentJobAssignment.JobPosition != null
                ? e.CurrentJobAssignment.JobPosition.Title : null,
            StatusName: e.Status.ToDisplayName(),
            Salary: e.Salary,
            SalaryTypeName: e.SalaryType.ToDisplayName()
        ));

    public static IQueryable<HREmployee> BuildSearchQuery(this IQueryable<HREmployee> query, SearchHREmployeesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(e =>
                (e.EmployeeNumber != null && EF.Functions.ILike(e.EmployeeNumber, term))
                || (e.FamilyMember != null && EF.Functions.ILike(e.FamilyMember.FullName, term))
                || (e.EmergencyContactName != null && EF.Functions.ILike(e.EmergencyContactName, term))
                || (e.Notes != null && EF.Functions.ILike(e.Notes, term)));
        }
        if (!string.IsNullOrEmpty(search.FarmId))
            query = query.Where(e => e.FarmId == search.FarmId);
        if (search.Status.HasValue)
            query = query.Where(e => e.Status == search.Status.Value);
        return query;
    }

    /// <summary>sortBy: employeenumber, status, salary, hiredate</summary>
    public static IQueryable<HREmployee> ApplySorting(this IQueryable<HREmployee> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.Created).ThenBy(a => a.EmployeeNumber);
        return sortBy.ToLower() switch
        {
            "employeenumber" => ascending ? query.OrderBy(a => a.EmployeeNumber) : query.OrderByDescending(a => a.EmployeeNumber),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "salary" => ascending ? query.OrderBy(a => a.Salary) : query.OrderByDescending(a => a.Salary),
            "hiredate" => ascending ? query.OrderBy(a => a.HireDate) : query.OrderByDescending(a => a.HireDate),
            _ => query
        };
    }

    //======================================== JobPosition ========================================

    public static IQueryable<JobPositionDto> ToJobPositionDto(this IQueryable<JobPosition> query)
        => query.Select(p => new JobPositionDto(
            Id: p.Id,
            Title: p.Title,
            Description: p.Description,
            MinSalary: p.MinSalary,
            MaxSalary: p.MaxSalary,
            DepartmentId: p.DepartmentId,
            DepartmentName: p.Department != null ? p.Department.Name : null,
            RequiredQualifications: p.RequiredQualifications,
            IsActive: p.IsActive,
            NumberOfPositions: p.NumberOfPositions,
            Notes: p.Notes,
            Created: p.Created
        ));

    public static IQueryable<JobPositionSummaryDto> ToJobPositionSummaryDto(this IQueryable<JobPosition> query)
        => query.Select(p => new JobPositionSummaryDto(
            Id: p.Id,
            Title: p.Title,
            DepartmentName: p.Department != null ? p.Department.Name : null,
            MinSalary: p.MinSalary,
            MaxSalary: p.MaxSalary,
            IsActive: p.IsActive,
            NumberOfPositions: p.NumberOfPositions
        ));

    public static IQueryable<JobPosition> BuildSearchQuery(this IQueryable<JobPosition> query, SearchJobPositionsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(p => EF.Functions.ILike(p.Title, term)
                || (p.Description != null && EF.Functions.ILike(p.Description, term))
                || (p.RequiredQualifications != null && EF.Functions.ILike(p.RequiredQualifications, term)));
        }
        if (search.IsActive.HasValue)
            query = query.Where(p => p.IsActive == search.IsActive.Value);
        return query;
    }

    /// <summary>sortBy: title, isactive</summary>
    public static IQueryable<JobPosition> ApplySorting(this IQueryable<JobPosition> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.Created).ThenBy(a => a.Title);
        return sortBy.ToLower() switch
        {
            "title" => ascending ? query.OrderBy(a => a.Title) : query.OrderByDescending(a => a.Title),
            "isactive" => ascending ? query.OrderBy(a => a.IsActive) : query.OrderByDescending(a => a.IsActive),
            _ => query
        };
    }

    //======================================== JobAssignment ========================================

    public static IQueryable<JobAssignmentDto> ToJobAssignmentDto(this IQueryable<JobAssignment> query)
        => query.Select(a => new JobAssignmentDto(
            Id: a.Id,
            HREmployeeId: a.HREmployeeId,
            EmployeeName: a.HREmployee != null && a.HREmployee.FamilyMember != null ? a.HREmployee.FamilyMember.FullName : null,
            EmployeeNumber: a.HREmployee != null ? a.HREmployee.EmployeeNumber : null,
            JobPositionId: a.JobPositionId,
            JobPositionTitle: a.JobPosition != null ? a.JobPosition.Title : null,
            StartDate: a.StartDate,
            EndDate: a.EndDate,
            StatusName: a.Status.ToDisplayName(),
            AssignedSalary: a.AssignedSalary,
            AssignedFieldId: a.AssignedFieldId,
            AssignedFieldName: a.AssignedField != null ? a.AssignedField.Name : null,
            SupervisorId: a.SupervisorId,
            SupervisorName: a.Supervisor != null && a.Supervisor.FamilyMember != null ? a.Supervisor.FamilyMember.FullName : null,
            PerformanceNotes: a.PerformanceNotes,
            AssignmentReason: a.AssignmentReason,
            Created: a.Created
        ));

    public static IQueryable<JobAssignmentSummaryDto> ToJobAssignmentSummaryDto(this IQueryable<JobAssignment> query)
        => query.Select(a => new JobAssignmentSummaryDto(
            Id: a.Id,
            EmployeeName: a.HREmployee != null && a.HREmployee.FamilyMember != null ? a.HREmployee.FamilyMember.FullName : null,
            JobPositionTitle: a.JobPosition != null ? a.JobPosition.Title : null,
            FieldName: a.AssignedField != null ? a.AssignedField.Name : null,
            StatusName: a.Status.ToDisplayName(),
            StartDate: a.StartDate,
            EndDate: a.EndDate
        ));

    public static IQueryable<JobAssignment> BuildSearchQuery(this IQueryable<JobAssignment> query, SearchJobAssignmentsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(a =>
                (a.AssignmentReason != null && EF.Functions.ILike(a.AssignmentReason, term))
                || (a.PerformanceNotes != null && EF.Functions.ILike(a.PerformanceNotes, term))
                || (a.HREmployee != null && a.HREmployee.FamilyMember != null && EF.Functions.ILike(a.HREmployee.FamilyMember.FullName, term))
                || (a.JobPosition != null && EF.Functions.ILike(a.JobPosition.Title, term)));
        }
        if (!string.IsNullOrEmpty(search.HREmployeeId))
            query = query.Where(a => a.HREmployeeId == search.HREmployeeId);
        if (!string.IsNullOrEmpty(search.JobPositionId))
            query = query.Where(a => a.JobPositionId == search.JobPositionId);
        if (search.Status.HasValue)
            query = query.Where(a => a.Status == search.Status.Value);
        return query;
    }

    /// <summary>sortBy: startdate, status</summary>
    public static IQueryable<JobAssignment> ApplySorting(this IQueryable<JobAssignment> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.StartDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "startdate" => ascending ? query.OrderBy(a => a.StartDate) : query.OrderByDescending(a => a.StartDate),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            _ => query
        };
    }

    //======================================== EmployeeAttendance ========================================

    public static IQueryable<EmployeeAttendanceDto> ToEmployeeAttendanceDto(this IQueryable<EmployeeAttendance> query)
        => query.Select(a => new EmployeeAttendanceDto(
            Id: a.Id,
            HREmployeeId: a.HREmployeeId,
            EmployeeName: a.HREmployee != null && a.HREmployee.FamilyMember != null ? a.HREmployee.FamilyMember.FullName : null,
            EmployeeNumber: a.HREmployee != null ? a.HREmployee.EmployeeNumber : null,
            AttendanceDate: a.AttendanceDate,
            CheckInTime: a.CheckInTime,
            CheckOutTime: a.CheckOutTime,
            WorkShiftId: a.WorkShiftId,
            WorkShiftName: a.WorkShift != null ? a.WorkShift.Name : null,
            StatusName: a.Status.ToDisplayName(),
            Reason: a.Reason,
            HoursWorked: a.HoursWorked,
            OvertimeHours: a.OvertimeHours,
            Notes: a.Notes,
            Created: a.Created
        ));

    public static IQueryable<EmployeeAttendanceSummaryDto> ToEmployeeAttendanceSummaryDto(this IQueryable<EmployeeAttendance> query)
        => query.Select(a => new EmployeeAttendanceSummaryDto(
            Id: a.Id,
            EmployeeName: a.HREmployee != null && a.HREmployee.FamilyMember != null ? a.HREmployee.FamilyMember.FullName : null,
            AttendanceDate: a.AttendanceDate,
            CheckInTime: a.CheckInTime,
            CheckOutTime: a.CheckOutTime,
            StatusName: a.Status.ToDisplayName(),
            HoursWorked: a.HoursWorked,
            OvertimeHours: a.OvertimeHours
        ));

    public static IQueryable<EmployeeAttendance> BuildSearchQuery(this IQueryable<EmployeeAttendance> query, SearchEmployeeAttendancesQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(a =>
                (a.Reason != null && EF.Functions.ILike(a.Reason, term))
                || (a.Notes != null && EF.Functions.ILike(a.Notes, term))
                || (a.HREmployee != null && a.HREmployee.FamilyMember != null && EF.Functions.ILike(a.HREmployee.FamilyMember.FullName, term)));
        }
        if (!string.IsNullOrEmpty(search.HREmployeeId))
            query = query.Where(a => a.HREmployeeId == search.HREmployeeId);
        if (!string.IsNullOrEmpty(search.WorkShiftId))
            query = query.Where(a => a.WorkShiftId == search.WorkShiftId);
        if (search.Status.HasValue)
            query = query.Where(a => a.Status == search.Status.Value);
        if (search.AttendanceDate.HasValue)
            query = query.Where(a => a.AttendanceDate == search.AttendanceDate.Value);
        return query;
    }

    /// <summary>sortBy: attendancedate, status</summary>
    public static IQueryable<EmployeeAttendance> ApplySorting(this IQueryable<EmployeeAttendance> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.AttendanceDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "attendancedate" => ascending ? query.OrderBy(a => a.AttendanceDate) : query.OrderByDescending(a => a.AttendanceDate),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            _ => query
        };
    }

    //======================================== WorkShift ========================================

    public static IQueryable<WorkShiftDto> ToWorkShiftDto(this IQueryable<WorkShift> query)
        => query.Select(s => new WorkShiftDto(
            Id: s.Id,
            Name: s.Name,
            StartTime: s.StartTime,
            EndTime: s.EndTime,
            FarmId: s.FarmId,
            FarmName: s.Farm != null ? s.Farm.Name : null,
            Created: s.Created
        ));

    public static IQueryable<WorkShiftSummaryDto> ToWorkShiftSummaryDto(this IQueryable<WorkShift> query)
        => query.Select(s => new WorkShiftSummaryDto(
            Id: s.Id,
            Name: s.Name,
            StartTime: s.StartTime,
            EndTime: s.EndTime
        ));

    public static IQueryable<WorkShift> BuildSearchQuery(this IQueryable<WorkShift> query, SearchWorkShiftsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(s => EF.Functions.ILike(s.Name, term));
        }
        if (!string.IsNullOrEmpty(search.FarmId))
            query = query.Where(s => s.FarmId == search.FarmId);
        return query;
    }

    /// <summary>sortBy: name, starttime</summary>
    public static IQueryable<WorkShift> ApplySorting(this IQueryable<WorkShift> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderBy(a => a.StartTime).ThenBy(a => a.Name);
        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name),
            "starttime" => ascending ? query.OrderBy(a => a.StartTime) : query.OrderByDescending(a => a.StartTime),
            _ => query
        };
    }

    //======================================== LeaveRequest ========================================

    public static IQueryable<LeaveRequestDto> ToLeaveRequestDto(this IQueryable<LeaveRequest> query)
        => query.Select(l => new LeaveRequestDto(
            Id: l.Id,
            HREmployeeId: l.HREmployeeId,
            EmployeeName: l.HREmployee != null && l.HREmployee.FamilyMember != null ? l.HREmployee.FamilyMember.FullName : null,
            EmployeeNumber: l.HREmployee != null ? l.HREmployee.EmployeeNumber : null,
            LeaveType: l.LeaveType,
            FromDate: l.FromDate,
            ToDate: l.ToDate,
            Reason: l.Reason,
            Status: l.Status,
            ApprovedBy: l.ApprovedBy,
            ApprovedAt: l.ApprovedAt,
            Created: l.Created
        ));

    public static IQueryable<LeaveRequestSummaryDto> ToLeaveRequestSummaryDto(this IQueryable<LeaveRequest> query)
        => query.Select(l => new LeaveRequestSummaryDto(
            Id: l.Id,
            EmployeeName: l.HREmployee != null && l.HREmployee.FamilyMember != null ? l.HREmployee.FamilyMember.FullName : null,
            LeaveType: l.LeaveType,
            FromDate: l.FromDate,
            ToDate: l.ToDate,
            Status: l.Status
        ));

    public static IQueryable<LeaveRequest> BuildSearchQuery(this IQueryable<LeaveRequest> query, SearchLeaveRequestsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(l => EF.Functions.ILike(l.LeaveType, term)
                || (l.Reason != null && EF.Functions.ILike(l.Reason, term))
                || (l.HREmployee != null && l.HREmployee.FamilyMember != null && EF.Functions.ILike(l.HREmployee.FamilyMember.FullName, term)));
        }
        if (!string.IsNullOrEmpty(search.HREmployeeId))
            query = query.Where(l => l.HREmployeeId == search.HREmployeeId);
        if (!string.IsNullOrEmpty(search.Status))
            query = query.Where(l => l.Status == search.Status);
        return query;
    }

    /// <summary>sortBy: fromdate, status, leavetype</summary>
    public static IQueryable<LeaveRequest> ApplySorting(this IQueryable<LeaveRequest> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.FromDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "fromdate" => ascending ? query.OrderBy(a => a.FromDate) : query.OrderByDescending(a => a.FromDate),
            "status" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "leavetype" => ascending ? query.OrderBy(a => a.LeaveType) : query.OrderByDescending(a => a.LeaveType),
            _ => query
        };
    }

    //======================================== Payroll ========================================

    public static IQueryable<PayrollDto> ToPayrollDto(this IQueryable<Payroll> query)
        => query.Select(p => new PayrollDto(
            Id: p.Id,
            HREmployeeId: p.HREmployeeId,
            EmployeeName: p.HREmployee != null && p.HREmployee.FamilyMember != null ? p.HREmployee.FamilyMember.FullName : null,
            EmployeeNumber: p.HREmployee != null ? p.HREmployee.EmployeeNumber : null,
            PeriodStartDate: p.PeriodStartDate,
            PeriodEndDate: p.PeriodEndDate,
            BaseSalary: p.BaseSalary,
            DaysWorked: p.DaysWorked,
            OvertimeHours: p.OvertimeHours,
            OvertimeAmount: p.OvertimeAmount,
            BonusAmount: p.BonusAmount,
            Deductions: p.Deductions,
            DeductionDetails: p.DeductionDetails,
            NetAmount: p.NetAmount,
            PaymentStatusName: p.PaymentStatus.ToDisplayName(),
            PaymentDate: p.PaymentDate,
            PaymentMethod: p.PaymentMethod,
            ReferenceNumber: p.ReferenceNumber,
            Notes: p.Notes,
            Created: p.Created
        ));

    public static IQueryable<PayrollSummaryDto> ToPayrollSummaryDto(this IQueryable<Payroll> query)
        => query.Select(p => new PayrollSummaryDto(
            Id: p.Id,
            EmployeeName: p.HREmployee != null && p.HREmployee.FamilyMember != null ? p.HREmployee.FamilyMember.FullName : null,
            PeriodStartDate: p.PeriodStartDate,
            PeriodEndDate: p.PeriodEndDate,
            NetAmount: p.NetAmount,
            PaymentStatusName: p.PaymentStatus.ToDisplayName(),
            PaymentDate: p.PaymentDate
        ));

    public static IQueryable<Payroll> BuildSearchQuery(this IQueryable<Payroll> query, SearchPayrollsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(p =>
                (p.ReferenceNumber != null && EF.Functions.ILike(p.ReferenceNumber, term))
                || (p.PaymentMethod != null && EF.Functions.ILike(p.PaymentMethod, term))
                || (p.Notes != null && EF.Functions.ILike(p.Notes, term))
                || (p.HREmployee != null && p.HREmployee.FamilyMember != null && EF.Functions.ILike(p.HREmployee.FamilyMember.FullName, term)));
        }
        if (!string.IsNullOrEmpty(search.HREmployeeId))
            query = query.Where(p => p.HREmployeeId == search.HREmployeeId);
        if (search.PaymentStatus.HasValue)
            query = query.Where(p => p.PaymentStatus == search.PaymentStatus.Value);
        return query;
    }

    /// <summary>sortBy: periodstartdate, netamount, paymentstatus</summary>
    public static IQueryable<Payroll> ApplySorting(this IQueryable<Payroll> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.PeriodStartDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "periodstartdate" => ascending ? query.OrderBy(a => a.PeriodStartDate) : query.OrderByDescending(a => a.PeriodStartDate),
            "netamount" => ascending ? query.OrderBy(a => a.NetAmount) : query.OrderByDescending(a => a.NetAmount),
            "paymentstatus" => ascending ? query.OrderBy(a => a.PaymentStatus) : query.OrderByDescending(a => a.PaymentStatus),
            _ => query
        };
    }

    //======================================== EmployeeContract ========================================

    public static IQueryable<EmployeeContractDto> ToEmployeeContractDto(this IQueryable<EmployeeContract> query)
        => query.Select(c => new EmployeeContractDto(
            Id: c.Id,
            HREmployeeId: c.HREmployeeId,
            EmployeeName: c.HREmployee != null && c.HREmployee.FamilyMember != null ? c.HREmployee.FamilyMember.FullName : null,
            EmployeeNumber: c.HREmployee != null ? c.HREmployee.EmployeeNumber : null,
            ContractNumber: c.ContractNumber,
            ContractType: c.ContractType,
            StartDate: c.StartDate,
            EndDate: c.EndDate,
            SalaryTypeName: c.SalaryType.ToDisplayName(),
            BaseSalary: c.BaseSalary,
            IsActive: c.IsActive,
            Created: c.Created
        ));

    public static IQueryable<EmployeeContractSummaryDto> ToEmployeeContractSummaryDto(this IQueryable<EmployeeContract> query)
        => query.Select(c => new EmployeeContractSummaryDto(
            Id: c.Id,
            EmployeeName: c.HREmployee != null && c.HREmployee.FamilyMember != null ? c.HREmployee.FamilyMember.FullName : null,
            ContractNumber: c.ContractNumber,
            ContractType: c.ContractType,
            StartDate: c.StartDate,
            EndDate: c.EndDate,
            IsActive: c.IsActive
        ));

    public static IQueryable<EmployeeContract> BuildSearchQuery(this IQueryable<EmployeeContract> query, SearchEmployeeContractsQuery search)
    {
        if (!string.IsNullOrEmpty(search.Term))
        {
            var term = $"%{search.Term.Trim()}%";
            query = query.Where(c => EF.Functions.ILike(c.ContractNumber, term)
                || EF.Functions.ILike(c.ContractType, term)
                || (c.HREmployee != null && c.HREmployee.FamilyMember != null && EF.Functions.ILike(c.HREmployee.FamilyMember.FullName, term)));
        }
        if (!string.IsNullOrEmpty(search.HREmployeeId))
            query = query.Where(c => c.HREmployeeId == search.HREmployeeId);
        if (!string.IsNullOrEmpty(search.ContractType))
            query = query.Where(c => c.ContractType == search.ContractType);
        if (search.IsActive.HasValue)
            query = query.Where(c => c.IsActive == search.IsActive.Value);
        return query;
    }

    /// <summary>sortBy: startdate, contractnumber, isactive<///summary>
    public static IQueryable<EmployeeContract> ApplySorting(this IQueryable<EmployeeContract> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return query.OrderByDescending(a => a.StartDate).ThenByDescending(a => a.Created);
        return sortBy.ToLower() switch
        {
            "startdate" => ascending ? query.OrderBy(a => a.StartDate) : query.OrderByDescending(a => a.StartDate),
            "contractnumber" => ascending ? query.OrderBy(a => a.ContractNumber) : query.OrderByDescending(a => a.ContractNumber),
            "isactive" => ascending ? query.OrderBy(a => a.IsActive) : query.OrderByDescending(a => a.IsActive),
            _ => query
        };
    }
}