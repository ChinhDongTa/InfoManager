namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record SearchJobAssignmentsQuery(string? Term, string? HREmployeeId, string? JobPositionId, AssignmentStatus? Status, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<JobAssignmentSummaryDto>>>;
public class SearchJobAssignmentsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchJobAssignmentsQuery, Result<PaginatedList<JobAssignmentSummaryDto>>>
{
    public async Task<Result<PaginatedList<JobAssignmentSummaryDto>>> Handle(SearchJobAssignmentsQuery request, CancellationToken cancellationToken)
    {
        var paged = await context.JobAssignments.BuildSearchQuery(request)
            .ApplySorting()
            .ToJobAssignmentSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<JobAssignmentSummaryDto>>.Success(paged);
    }
}