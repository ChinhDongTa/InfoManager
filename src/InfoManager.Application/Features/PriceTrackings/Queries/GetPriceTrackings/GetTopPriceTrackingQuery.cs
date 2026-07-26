using InfoManager.Shared.Dtos.PriceTrackings;

namespace InfoManager.Application.Features.PriceTrackings.Queries.GetPriceTrackings;

public record GetTopPriceTrackingsQuery(int Top=5) : IRequest<Result<List<PriceTrackingSummaryDto>>>;
public class GetTopPriceTrackingsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTopPriceTrackingsQuery, Result<List<PriceTrackingSummaryDto>>>
{
    public async Task<Result<List<PriceTrackingSummaryDto>>> Handle(GetTopPriceTrackingsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.PriceTrackings
            .ApplySorting()
            .Take(request.Top)
            .ToPriceTrackingSummaryDto()
            .ToListResultAsync(cancellationToken);
        return result;
    }
}
