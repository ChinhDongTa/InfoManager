using InfoManager.Shared.Dtos.Intentions;

namespace InfoManager.Application.Features.Intentions.Queries.GetIntentions;

public record GetIntentionByIdQuery(string Id) : IRequest<Result<IntentionDto?>>;

public class GetIntentionByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetIntentionByIdQuery, Result<IntentionDto?>>
{
    public async Task<Result<IntentionDto?>> Handle(GetIntentionByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Intentions
            .Where(i => i.Id == request.Id)
           .ToIntentionDto()
           .SingleOrNotFoundAsync(nameof(IntentionDto), request.Id, cancellationToken);
        return result;
    }
}