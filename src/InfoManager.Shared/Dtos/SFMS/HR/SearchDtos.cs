namespace InfoManager.Shared.Dtos.SFMS.HR;

public record SearchDepartmentsRequest(string? Term, string? FarmId, string? ParentId, int PageNumber, int PageSize);

public record SearchHREmployeesRequest(string? Term, string? FarmId, string? DepartmentId, EmploymentStatus? Status, int PageNumber, int PageSize);

public record SearchJobPositionsRequest(string? Term, string? DepartmentId, bool? IsActive, int PageNumber, int PageSize);

public record SearchJobAssignmentsRequest(string? Term, string? HREmployeeId, string? JobPositionId, AssignmentStatus? Status, int PageNumber, int PageSize);

public record SearchEmployeeAttendancesRequest(string? Term, string? HREmployeeId, string? WorkShiftId, AttendanceStatus? Status, DateOnly? AttendanceDate, int PageNumber, int PageSize);

public record SearchWorkShiftsRequest(string? Term, string? FarmId, int PageNumber, int PageSize);

public record SearchLeaveRequestsRequest(string? Term, string? HREmployeeId, string? Status, int PageNumber, int PageSize);

public record SearchPayrollsRequest(string? Term, string? HREmployeeId, PayrollStatus? PaymentStatus, int PageNumber, int PageSize);

public record SearchEmployeeContractsRequest(string? Term, string? HREmployeeId, string? ContractType, bool? IsActive, int PageNumber, int PageSize);