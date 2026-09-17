using InfoManager.Shared.Dtos.SFMS.Resources;

namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record SearchPesticidePlansQuery(string? Term, string? FarmId, string? PesticideId, PesticidePlanStatus? Status, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<PesticidePlanSummaryDto>>>;
public class SearchPesticidePlansQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchPesticidePlansQuery, Result<PaginatedList<PesticidePlanSummaryDto>>>
{
    public async Task<Result<PaginatedList<PesticidePlanSummaryDto>>> Handle(
        SearchPesticidePlansQuery request, CancellationToken ct)
    {
        var query = Context.PesticidePlans.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToPesticidePlanSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PesticidePlanSummaryDto>>.Success(paged);
    }
}