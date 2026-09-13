using InfoManager.Shared.Dtos.SFMS.Planning;

namespace InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

public record SearchCropCyclesQuery(
    string? Term,
    int? StartYear,
    CropCycleStatus? Status,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<CropCycleSummaryDto>>>;
public class SearchCropCyclesQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchCropCyclesQuery, Result<PaginatedList<CropCycleSummaryDto>>>
{
    public async Task<Result<PaginatedList<CropCycleSummaryDto>>> Handle(
        SearchCropCyclesQuery request, CancellationToken cancellationToken)
    {
        var query = Context.CropCycles.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToCropCycleSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<CropCycleSummaryDto>>.Success(paged);
    }
}