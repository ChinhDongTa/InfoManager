using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.Application.Features.Intentions.Queries.GetIntentions;

public record SearchIntentionsQuery : IRequest<Result<PaginatedList<IntentionSummaryDto>>>
{
    public string? SearchTerm { get; init; }
    public string? CategoryId { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}

public class SearchIntentionsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchIntentionsQuery, Result<PaginatedList<IntentionSummaryDto>>>
{
    public async Task<Result<PaginatedList<IntentionSummaryDto>>> Handle(SearchIntentionsQuery request, CancellationToken ct)
    {
        var query = context.Intentions.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            query = query.Where(i => EF.Functions.ILike(i.Content, $"%{request.SearchTerm}%") || (i.Description != null && EF.Functions.ILike(i.Description, $"%{request.SearchTerm}%")));
        }
        if (!string.IsNullOrWhiteSpace(request.CategoryId))
        {
            query = query.Where(i => i.CategoryId == request.CategoryId);
        }
        if (request.StartDate.HasValue)
        {
            query = query.Where(i => i.PlannDate.HasValue && i.PlannDate.Value.Date >= request.StartDate.Value.Date);
        }
        if (request.EndDate.HasValue)
        {
            query = query.Where(i => i.PlannDate.HasValue && i.PlannDate.Value.Date <= request.EndDate.Value.Date);
        }
        var result = await query
            .ApplySorting()
            .ToIntentionSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<IntentionSummaryDto>>.Success(result);
    }
}