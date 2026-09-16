namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record GetPestsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<PestSummaryDto>>>;

public class GetPestsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPestsQuery, Result<PaginatedList<PestSummaryDto>>>
{
    public async Task<Result<PaginatedList<PestSummaryDto>>> Handle(GetPestsQuery request, CancellationToken ct)
    {
        var result = await context.Pests
            .ApplySorting()
            .ToPestSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PestSummaryDto>>.Success(result);
    }
}