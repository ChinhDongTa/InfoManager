using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record SearchPesticidesQuery(string? Term, PesticideType? PesticideType, bool? IsActive, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<PesticideSummaryDto>>>;
public class SearchPesticidesQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchPesticidesQuery, Result<PaginatedList<PesticideSummaryDto>>>
{
    public async Task<Result<PaginatedList<PesticideSummaryDto>>> Handle(
        SearchPesticidesQuery request, CancellationToken ct)
    {
        var query = Context.Pesticides.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToPesticideSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PesticideSummaryDto>>.Success(paged);
    }
}