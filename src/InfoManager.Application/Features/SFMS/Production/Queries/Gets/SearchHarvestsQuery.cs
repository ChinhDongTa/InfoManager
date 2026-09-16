namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record SearchHarvestsQuery(string? Term, string? CropPlantingId, string? QualityGrade, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<HarvestSummaryDto>>>;

public class SearchHarvestsQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchHarvestsQuery, Result<PaginatedList<HarvestSummaryDto>>>
{
    public async Task<Result<PaginatedList<HarvestSummaryDto>>> Handle(
        SearchHarvestsQuery request, CancellationToken ct)
    {
        var query = Context.Harvests.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToHarvestSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<HarvestSummaryDto>>.Success(paged);
    }
}