namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record SearchJobPositionsQuery(string? Term, string? JobPositionId, bool? IsActive, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<JobPositionSummaryDto>>>;
public class SearchJobPositionsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchJobPositionsQuery, Result<PaginatedList<JobPositionSummaryDto>>>
{
    public async Task<Result<PaginatedList<JobPositionSummaryDto>>> Handle(SearchJobPositionsQuery request, CancellationToken cancellationToken)
    {
        var paged = await context.JobPositions.BuildSearchQuery(request)
            .ApplySorting()
            .ToJobPositionSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<JobPositionSummaryDto>>.Success(paged);
    }
}