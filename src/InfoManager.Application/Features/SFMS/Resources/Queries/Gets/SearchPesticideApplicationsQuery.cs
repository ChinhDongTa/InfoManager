using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record SearchPesticideApplicationsQuery(string? Term, string? FarmId, string? PesticideId, string? CropPlantingId, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<PesticideApplicationSummaryDto>>>; 
public class SearchPesticideApplicationsQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchPesticideApplicationsQuery, Result<PaginatedList<PesticideApplicationSummaryDto>>>
{
    public async Task<Result<PaginatedList<PesticideApplicationSummaryDto>>> Handle(
        SearchPesticideApplicationsQuery request, CancellationToken ct)
    {
        var query = Context.PesticideApplications.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToPesticideApplicationSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PesticideApplicationSummaryDto>>.Success(paged);
    }
}