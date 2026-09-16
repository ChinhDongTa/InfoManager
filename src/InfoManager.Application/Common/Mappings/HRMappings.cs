using InfoManager.Application.Features.SFMS.HR.Commands;
using InfoManager.Application.Features.SFMS.HR.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

public static class HRMappings
{
    public static SearchDepartmentsQuery ToSearchQuery(SearchDepartmentsRequest request)
       => new(request.Term, request.FarmId, request.ParentId, request.PageNumber, request.PageSize);

    public static SearchHREmployeesQuery ToSearchQuery(SearchHREmployeesRequest request)
        => new(request.Term, request.FarmId, request.DepartmentId, request.Status, request.PageNumber, request.PageSize);

    public static SearchJobPositionsQuery ToSearchQuery(SearchJobPositionsRequest request)
        => new(request.Term, request.DepartmentId, request.IsActive, request.PageNumber, request.PageSize);

    public static SearchJobAssignmentsQuery ToSearchQuery(SearchJobAssignmentsRequest request)
        => new(request.Term, request.HREmployeeId, request.JobPositionId, request.Status, request.PageNumber, request.PageSize);

    public static SearchEmployeeAttendancesQuery ToSearchQuery(SearchEmployeeAttendancesRequest request)
        => new(request.Term, request.HREmployeeId, request.WorkShiftId, request.Status, request.AttendanceDate, request.PageNumber, request.PageSize);

    public static SearchWorkShiftsQuery ToSearchQuery(SearchWorkShiftsRequest request)
        => new(request.Term, request.FarmId, request.PageNumber, request.PageSize);

    public static SearchLeaveRequestsQuery ToSearchQuery(SearchLeaveRequestsRequest request)
        => new(request.Term, request.HREmployeeId, request.Status, request.PageNumber, request.PageSize);

    public static SearchPayrollsQuery ToSearchQuery(SearchPayrollsRequest request)
        => new(request.Term, request.HREmployeeId, request.PaymentStatus, request.PageNumber, request.PageSize);

    public static SearchEmployeeContractsQuery ToSearchQuery(SearchEmployeeContractsRequest request)
        => new(request.Term, request.HREmployeeId, request.ContractType, request.IsActive, request.PageNumber, request.PageSize);

    public static CreateDepartmentCommand ToCreateCommand(CreateDepartmentRequest request)
        => new()
        {
            Name = request.Name,
            Description = request.Description,
            ParentId = request.ParentId,
            FarmId = request.FarmId
        };

    public static UpdateDepartmentCommand ToUpdateCommand(UpdateDepartmentRequest request, string id)
        => new()
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            ParentId = request.ParentId
        };

    public static CreateHREmployeeCommand ToCreateCommand(CreateHREmployeeRequest request)
        => new()
        {
            FamilyMemberId = request.FamilyMemberId,
            FarmId = request.FarmId,
            UserId = request.UserId,
            DepartmentId = request.DepartmentId,
            EmployeeNumber = request.EmployeeNumber,
            Status = request.Status,
            HireDate = request.HireDate,
            Salary = request.Salary,
            SalaryType = request.SalaryType,
            BankAccount = request.BankAccount,
            EmergencyContactName = request.EmergencyContactName,
            EmergencyContactPhone = request.EmergencyContactPhone,
            Notes = request.Notes
        };

    public static UpdateHREmployeeCommand ToUpdateCommand(UpdateHREmployeeRequest request, string id)
        => new()
        {
            Id = id,
            FamilyMemberId = request.FamilyMemberId,
            DepartmentId = request.DepartmentId,
            EmployeeNumber = request.EmployeeNumber,
            Status = request.Status,
            HireDate = request.HireDate,
            TerminationDate = request.TerminationDate,
            TerminationReason = request.TerminationReason,
            Salary = request.Salary,
            SalaryType = request.SalaryType,
            BankAccount = request.BankAccount,
            EmergencyContactName = request.EmergencyContactName,
            EmergencyContactPhone = request.EmergencyContactPhone,
            Notes = request.Notes
        };

    public static CreateJobPositionCommand ToCreateCommand(CreateJobPositionRequest request)
        => new()
        {
            Title = request.Title,
            Description = request.Description,
            MinSalary = request.MinSalary,
            MaxSalary = request.MaxSalary,
            DepartmentId = request.DepartmentId,
            RequiredQualifications = request.RequiredQualifications,
            IsActive = request.IsActive,
            NumberOfPositions = request.NumberOfPositions,
            Notes = request.Notes
        };

    public static UpdateJobPositionCommand ToUpdateCommand(UpdateJobPositionRequest request, string id)
        => new()
        {
            Id = id,
            Title = request.Title,
            Description = request.Description,
            MinSalary = request.MinSalary,
            MaxSalary = request.MaxSalary,
            DepartmentId = request.DepartmentId,
            RequiredQualifications = request.RequiredQualifications,
            IsActive = request.IsActive,
            NumberOfPositions = request.NumberOfPositions,
            Notes = request.Notes
        };

    public static CreateJobAssignmentCommand ToCreateCommand(CreateJobAssignmentRequest request)
        => new()
        {
            HREmployeeId = request.HREmployeeId,
            JobPositionId = request.JobPositionId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Status = request.Status,
            AssignedSalary = request.AssignedSalary,
            AssignedFieldId = request.AssignedFieldId,
            SupervisorId = request.SupervisorId,
            PerformanceNotes = request.PerformanceNotes,
            AssignmentReason = request.AssignmentReason
        };

    public static UpdateJobAssignmentCommand ToUpdateCommand(UpdateJobAssignmentRequest request, string id)
        => new()
        {
            Id = id,
            EndDate = request.EndDate,
            Status = request.Status,
            AssignedSalary = request.AssignedSalary,
            AssignedFieldId = request.AssignedFieldId,
            SupervisorId = request.SupervisorId,
            PerformanceNotes = request.PerformanceNotes,
            AssignmentReason = request.AssignmentReason
        };

    public static CreateEmployeeAttendanceCommand ToCreateCommand(CreateEmployeeAttendanceRequest request)
        => new()
        {
            HREmployeeId = request.HREmployeeId,
            AttendanceDate = request.AttendanceDate,
            CheckInTime = request.CheckInTime,
            CheckOutTime = request.CheckOutTime,
            WorkShiftId = request.WorkShiftId,
            Status = request.Status,
            Reason = request.Reason,
            HoursWorked = request.HoursWorked,
            OvertimeHours = request.OvertimeHours,
            Notes = request.Notes
        };

    public static UpdateEmployeeAttendanceCommand ToUpdateCommand(UpdateEmployeeAttendanceRequest request, string id)
        => new()
        {
            Id = id,
            CheckInTime = request.CheckInTime,
            CheckOutTime = request.CheckOutTime,
            WorkShiftId = request.WorkShiftId,
            Status = request.Status,
            Reason = request.Reason,
            HoursWorked = request.HoursWorked,
            OvertimeHours = request.OvertimeHours,
            Notes = request.Notes
        };

    public static CreateWorkShiftCommand ToCreateCommand(CreateWorkShiftRequest request)
        => new()
        {
            Name = request.Name,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            FarmId = request.FarmId
        };

    public static UpdateWorkShiftCommand ToUpdateCommand(UpdateWorkShiftRequest request, string id)
        => new()
        {
            Id = id,
            Name = request.Name,
            StartTime = request.StartTime,
            EndTime = request.EndTime
        };

    public static CreateLeaveRequestCommand ToCreateCommand(CreateLeaveRequestRequest request)
        => new()
        {
            HREmployeeId = request.HREmployeeId,
            LeaveType = request.LeaveType,
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            Reason = request.Reason
        };

    public static UpdateLeaveRequestCommand ToUpdateCommand(UpdateLeaveRequestRequest request, string id)
        => new()
        {
            Id = id,
            LeaveType = request.LeaveType,
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            Reason = request.Reason,
            Status = request.Status,
            ApprovedBy = request.ApprovedBy
        };

    public static CreatePayrollCommand ToCreateCommand(CreatePayrollRequest request)
        => new()
        {
            HREmployeeId = request.HREmployeeId,
            PeriodStartDate = request.PeriodStartDate,
            PeriodEndDate = request.PeriodEndDate,
            BaseSalary = request.BaseSalary,
            DaysWorked = request.DaysWorked,
            OvertimeHours = request.OvertimeHours,
            OvertimeAmount = request.OvertimeAmount,
            BonusAmount = request.BonusAmount,
            Deductions = request.Deductions,
            DeductionDetails = request.DeductionDetails,
            NetAmount = request.NetAmount,
            PaymentMethod = request.PaymentMethod,
            Notes = request.Notes
        };

    public static UpdatePayrollCommand ToUpdateCommand(UpdatePayrollRequest request, string id)
        => new()
        {
            Id = id,
            BaseSalary = request.BaseSalary,
            DaysWorked = request.DaysWorked,
            OvertimeHours = request.OvertimeHours,
            OvertimeAmount = request.OvertimeAmount,
            BonusAmount = request.BonusAmount,
            Deductions = request.Deductions,
            DeductionDetails = request.DeductionDetails,
            NetAmount = request.NetAmount,
            PaymentStatus = request.PaymentStatus,
            PaymentDate = request.PaymentDate,
            PaymentMethod = request.PaymentMethod,
            ReferenceNumber = request.ReferenceNumber,
            Notes = request.Notes
        };

    public static CreateEmployeeContractCommand ToCreateCommand(CreateEmployeeContractRequest request)
        => new()
        {
            HREmployeeId = request.HREmployeeId,
            ContractNumber = request.ContractNumber,
            ContractType = request.ContractType,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            SalaryType = request.SalaryType,
            BaseSalary = request.BaseSalary,
            IsActive = request.IsActive
        };

    public static UpdateEmployeeContractCommand ToUpdateCommand(UpdateEmployeeContractRequest request, string id)
        => new()
        {
            Id = id,
            ContractNumber = request.ContractNumber,
            ContractType = request.ContractType,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            SalaryType = request.SalaryType,
            BaseSalary = request.BaseSalary,
            IsActive = request.IsActive
        };
}