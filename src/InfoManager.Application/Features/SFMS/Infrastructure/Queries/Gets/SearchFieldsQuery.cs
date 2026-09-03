namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record SearchFieldsQuery(string? Term,
                               string? FarmId,
                               SoilCondition? SoilCondition,
                               FieldStatus? Status,
                               DateTimeOffset? StartLastPreparationDate,
                               DateTimeOffset? EndLastPreparationDate,
                               bool? HasIrrigation,
                               int PageNumber,
                               int PageSize) : IRequest<Result<PaginatedList<FieldSummaryDto>>>;
public class SearchFieldQueryHandler(IApplicationDbContext Context) : IRequestHandler<SearchFieldsQuery, Result<PaginatedList<FieldSummaryDto>>>
{
    public async Task<Result<PaginatedList<FieldSummaryDto>>> Handle(SearchFieldsQuery request, CancellationToken cancellationToken)
    {
        var query = Context.Fields.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToFieldSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FieldSummaryDto>>.Success(paged);
    }
}
