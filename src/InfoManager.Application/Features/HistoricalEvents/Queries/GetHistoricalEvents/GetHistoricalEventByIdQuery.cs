using InfoManager.Shared.Dtos.HistoricalEvents;

namespace InfoManager.Application.Features.HistoricalEvents.Queries.GetHistoricalEvents;

public record GetHistoricalEventByIdQuery(string Id) : IRequest<Result<HistoricalEventDto?>>;

public class GetHistoricalEventByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHistoricalEventByIdQuery, Result<HistoricalEventDto?>>
{
    public async Task<Result<HistoricalEventDto?>> Handle(GetHistoricalEventByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.HistoricalEvents
            .Where(e => e.Id == request.Id)
            .ToHistoricalEventDto()
            .SingleOrNotFoundAsync(nameof(HistoricalEvent), request.Id, cancellationToken);
        return result;
    }
}