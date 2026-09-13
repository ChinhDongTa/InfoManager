namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetEmployeeAttendanceByIdQuery(string Id) : IRequest<Result<EmployeeAttendanceDto?>>;
public class GetEmployeeAttendanceByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetEmployeeAttendanceByIdQuery, Result<EmployeeAttendanceDto?>>
{
    public async Task<Result<EmployeeAttendanceDto?>> Handle(GetEmployeeAttendanceByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.EmployeeAttendances
            .Where(x => x.Id == request.Id)
            .ToEmployeeAttendanceDto()
            .SingleOrNotFoundAsync(nameof(EmployeeAttendance), request.Id, cancellationToken);
        return result;
    }
}
