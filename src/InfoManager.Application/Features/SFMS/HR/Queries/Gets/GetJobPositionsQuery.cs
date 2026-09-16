namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetJobPositionsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<JobPositionSummaryDto>>>;

public class GetJobPositionsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetJobPositionsQuery, Result<PaginatedList<JobPositionSummaryDto>>>
{
    public async Task<Result<PaginatedList<JobPositionSummaryDto>>> Handle(GetJobPositionsQuery request, CancellationToken ct)
    {
        var result = await context.JobPositions
            .ApplySorting()
            .ToJobPositionSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<JobPositionSummaryDto>>.Success(result);
    }
}