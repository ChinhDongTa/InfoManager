namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record SearchEmployeeAttendancesQuery(string? Term, string? HREmployeeId, string? WorkShiftId, AttendanceStatus? Status, DateOnly? AttendanceDate, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<EmployeeAttendanceSummaryDto>>>;

public class SearchEmployeeAttendancesQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchEmployeeAttendancesQuery, Result<PaginatedList<EmployeeAttendanceSummaryDto>>>
{
    public async Task<Result<PaginatedList<EmployeeAttendanceSummaryDto>>> Handle(SearchEmployeeAttendancesQuery request, CancellationToken ct)
    {
        var paged = await context.EmployeeAttendances.BuildSearchQuery(request)
            .ApplySorting()
            .ToEmployeeAttendanceSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<EmployeeAttendanceSummaryDto>>.Success(paged);
    }
}