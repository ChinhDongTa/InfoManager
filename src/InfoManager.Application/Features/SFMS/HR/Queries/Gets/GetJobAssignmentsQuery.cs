namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetJobAssignmentsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<JobAssignmentSummaryDto>>>;

public class GetJobAssignmentsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetJobAssignmentsQuery, Result<PaginatedList<JobAssignmentSummaryDto>>>
{
    public async Task<Result<PaginatedList<JobAssignmentSummaryDto>>> Handle(GetJobAssignmentsQuery request, CancellationToken ct)
    {
        var result = await context.JobAssignments
            .ApplySorting()
            .ToJobAssignmentSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<JobAssignmentSummaryDto>>.Success(result);
    }
}