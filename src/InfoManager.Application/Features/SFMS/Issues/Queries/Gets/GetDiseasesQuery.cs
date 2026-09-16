namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record GetDiseasesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<DiseaseSummaryDto>>>;

public class GetDiseasesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetDiseasesQuery, Result<PaginatedList<DiseaseSummaryDto>>>
{
    public async Task<Result<PaginatedList<DiseaseSummaryDto>>> Handle(GetDiseasesQuery request, CancellationToken ct)
    {
        var result = await context.Diseases
            .ApplySorting()
            .ToDiseaseSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<DiseaseSummaryDto>>.Success(result);
    }
}