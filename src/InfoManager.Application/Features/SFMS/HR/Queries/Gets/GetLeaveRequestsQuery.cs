namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetLeaveRequestsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<LeaveRequestSummaryDto>>>;

public class GetLeaveRequestsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetLeaveRequestsQuery, Result<PaginatedList<LeaveRequestSummaryDto>>>
{
    public async Task<Result<PaginatedList<LeaveRequestSummaryDto>>> Handle(GetLeaveRequestsQuery request, CancellationToken ct)
    {
        var result = await context.LeaveRequests
            .ApplySorting()
            .ToLeaveRequestSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<LeaveRequestSummaryDto>>.Success(result);
    }
}