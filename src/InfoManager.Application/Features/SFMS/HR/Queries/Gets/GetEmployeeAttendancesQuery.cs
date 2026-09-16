namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetEmployeeAttendancesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<EmployeeAttendanceSummaryDto>>>;

public class GetEmployeeAttendancesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetEmployeeAttendancesQuery, Result<PaginatedList<EmployeeAttendanceSummaryDto>>>
{
    public async Task<Result<PaginatedList<EmployeeAttendanceSummaryDto>>> Handle(GetEmployeeAttendancesQuery request, CancellationToken ct)
    {
        var result = await context.EmployeeAttendances
            .ApplySorting()
            .ToEmployeeAttendanceSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<EmployeeAttendanceSummaryDto>>.Success(result);
    }
}