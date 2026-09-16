namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record GetYieldsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<YieldSummaryDto>>>;

public class GetYieldsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetYieldsQuery, Result<PaginatedList<YieldSummaryDto>>>
{
    public async Task<Result<PaginatedList<YieldSummaryDto>>> Handle(GetYieldsQuery request, CancellationToken ct)
    {
        var result = await context.Yields
            .ApplySorting()
            .ToYieldSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<YieldSummaryDto>>.Success(result);
    }
}