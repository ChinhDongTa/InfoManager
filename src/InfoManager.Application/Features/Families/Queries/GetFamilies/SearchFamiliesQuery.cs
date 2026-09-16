using InfoManager.Shared.Dtos.Families;

namespace InfoManager.Application.Features.Families.Queries.GetFamilies;

public record SearchFamiliesQuery : IRequest<Result<PaginatedList<FamilySummaryDto>>>
{
    public string? SearchTerm { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class SearchFamiliesQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchFamiliesQuery, Result<PaginatedList<FamilySummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilySummaryDto>>> Handle(SearchFamiliesQuery request, CancellationToken ct)
    {
        var query = context.Families.AsQueryable();
        var term = request.SearchTerm?.Trim();
        if (!string.IsNullOrEmpty(term))
        {
            query = query.Where(f => EF.Functions.ILike(f.Name, $"%{term}%")
                                || (f.Address != null && EF.Functions.ILike(f.Address, $"%{term}%"))
                                || (f.Email != null && EF.Functions.ILike(f.Email, $"%{term}%")));
        }
        var families = await query
            .ApplySorting()
            .ToFamilySummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FamilySummaryDto>>.Success(families);
    }
}