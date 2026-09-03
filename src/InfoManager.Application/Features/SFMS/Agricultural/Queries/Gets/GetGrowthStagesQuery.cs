namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetGrowthStagesQuery(int PageIndex, int PageSize) : IRequest<Result<PaginatedList<GrowthStageSummaryDto>>>;
public class GetGrowthStagesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetGrowthStagesQuery, Result<PaginatedList<GrowthStageSummaryDto>>>
{
    public async Task<Result<PaginatedList<GrowthStageSummaryDto>>> Handle(GetGrowthStagesQuery request, CancellationToken cancellationToken)
    {
        var result = await context.GrowthStages
            .ApplySorting()
            .ToGrowthStageSummaryDto()
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);
        return Result<PaginatedList<GrowthStageSummaryDto>>.Success(result);
    }
}
