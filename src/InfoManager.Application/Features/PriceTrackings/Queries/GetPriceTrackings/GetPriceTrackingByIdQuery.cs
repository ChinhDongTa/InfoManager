using InfoManager.Shared.Dtos.PriceTrackings;

namespace InfoManager.Application.Features.PriceTrackings.Queries.GetPriceTrackings;

public record GetPriceTrackingByIdQuery(string Id) : IRequest<Result<PriceTrackingDto?>>;

public class GetPriceTrackingByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPriceTrackingByIdQuery, Result<PriceTrackingDto?>>
{
    public async Task<Result<PriceTrackingDto?>> Handle(GetPriceTrackingByIdQuery request, CancellationToken ct)
    {
        var result = await context.PriceTrackings
            .Where(x => x.Id == request.Id)
            .ToPriceTrackingDto()
            .SingleOrNotFoundAsync(nameof(PriceTracking), request.Id, ct);
        return result;
    }
}