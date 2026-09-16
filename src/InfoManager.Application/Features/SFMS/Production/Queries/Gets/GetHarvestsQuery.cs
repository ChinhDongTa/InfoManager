namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record GetHarvestsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<HarvestSummaryDto>>>;

public class GetHarvestsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHarvestsQuery, Result<PaginatedList<HarvestSummaryDto>>>
{
    public async Task<Result<PaginatedList<HarvestSummaryDto>>> Handle(GetHarvestsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Harvests
            .ApplySorting()
            .ToHarvestSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<HarvestSummaryDto>>.Success(result);
    }
}