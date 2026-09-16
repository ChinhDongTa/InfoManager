namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetLeaveRequestByIdQuery(string Id) : IRequest<Result<LeaveRequestDto?>>;

public class GetLeaveRequestByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetLeaveRequestByIdQuery, Result<LeaveRequestDto?>>
{
    public async Task<Result<LeaveRequestDto?>> Handle(GetLeaveRequestByIdQuery request, CancellationToken ct)
    {
        var result = await context.LeaveRequests
            .Where(x => x.Id == request.Id)
            .ToLeaveRequestDto()
            .SingleOrNotFoundAsync(nameof(LeaveRequest), request.Id, ct);
        return result;
    }
}