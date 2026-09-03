using InfoManager.Shared.Dtos.Experiences;

namespace InfoManager.Application.Features.Experiences.Queries.GetExperiences;

public record SearchExperiencesQuery : IRequest<Result<PaginatedList<ExperienceSummaryDto>>>
{
    public string? Keyword { get; init; }
    public string? CategoryId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}
public class SearchExperiencesQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchExperiencesQuery, Result<PaginatedList<ExperienceSummaryDto>>>
{
    public async Task<Result<PaginatedList<ExperienceSummaryDto>>> Handle(SearchExperiencesQuery request, CancellationToken ct)
    {
        // Note: User filtering is now handled automatically by global query filter in DbContext
        var query = BuildSearchQuery(context.Experiences.AsQueryable(), request.Keyword, request.CategoryId);
        var paginated = await query.ApplySorting()
             .ToSummaryDto()
             .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<ExperienceSummaryDto>>.Success(paginated);
    }
    static IQueryable<Experience> BuildSearchQuery(IQueryable<Experience> query, string? keyword, string? categoryId)
    {
        if (!string.IsNullOrEmpty(keyword))
        {
            var key = $"%{keyword.Trim()}%";
            query = query.Where(e => EF.Functions.ILike(e.Content, key) || (e.Description != null && EF.Functions.ILike(e.Description, key)));
        }
        if (!string.IsNullOrEmpty(categoryId))
        {
            query = query.Where(e => e.CategoryId == categoryId);
        }
        return query;
    }
}