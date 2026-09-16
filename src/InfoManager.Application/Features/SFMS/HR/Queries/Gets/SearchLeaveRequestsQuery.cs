namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record SearchLeaveRequestsQuery(string? Term, string? HREmployeeId, string? Status, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<LeaveRequestSummaryDto>>>;

public class SearchLeaveRequestsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchLeaveRequestsQuery, Result<PaginatedList<LeaveRequestSummaryDto>>>
{
    public async Task<Result<PaginatedList<LeaveRequestSummaryDto>>> Handle(SearchLeaveRequestsQuery request, CancellationToken ct)
    {
        var paged = await context.LeaveRequests.BuildSearchQuery(request)
            .ApplySorting()
            .ToLeaveRequestSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<LeaveRequestSummaryDto>>.Success(paged);
    }
}