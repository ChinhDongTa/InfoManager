using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.Application.Features.Intentions.Queries.GetIntentions;

public record GetIntentionsQuery(int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<IntentionSummaryDto>>>;

public class GetIntentionsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetIntentionsQuery, Result<PaginatedList<IntentionSummaryDto>>>
{
    public async Task<Result<PaginatedList<IntentionSummaryDto>>> Handle(GetIntentionsQuery request, CancellationToken ct)
    {
        var result = await context.Intentions
            .ApplySorting()
            .ToIntentionSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<IntentionSummaryDto>>.Success(result);
    }
}