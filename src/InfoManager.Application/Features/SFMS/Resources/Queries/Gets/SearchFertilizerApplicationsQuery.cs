using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record SearchFertilizerApplicationsQuery(string? Term, string? FarmId, string? FertilizerId, string? CropPlantingId, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<FertilizerApplicationSummaryDto>>>;
public class SearchFertilizerApplicationsQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchFertilizerApplicationsQuery, Result<PaginatedList<FertilizerApplicationSummaryDto>>>
{
    public async Task<Result<PaginatedList<FertilizerApplicationSummaryDto>>> Handle(
        SearchFertilizerApplicationsQuery request, CancellationToken ct)
    {
        var query = Context.FertilizerApplications.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToFertilizerApplicationSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FertilizerApplicationSummaryDto>>.Success(paged);
    }
}