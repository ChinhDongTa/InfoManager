using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.Application.Features.Intentions.Queries.GetIntentions;

public record GetTopIntentionsQuery(int Top = 5) : IRequest<Result<List<IntentionSummaryDto>>>;
public class GetTopIntentionsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTopIntentionsQuery, Result<List<IntentionSummaryDto>>>
{
    public async Task<Result<List<IntentionSummaryDto>>> Handle(GetTopIntentionsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Intentions
            .Where(x => !x.IsCompleted)
            .ApplySorting()
            .Take(request.Top)
            .ToIntentionSummaryDto()
            .ToListResultAsync(cancellationToken);
        return result;
    }
}