namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetSensorByIdQuery(string Id) : IRequest<Result<SensorDto?>>;

public class GetSensorByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSensorByIdQuery, Result<SensorDto?>>
{
    public async Task<Result<SensorDto?>> Handle(GetSensorByIdQuery request, CancellationToken ct)
    {
        var result = await context.Sensors
            .Where(x => x.Id == request.Id)
            .ToSensorDto()
            .SingleOrNotFoundAsync(nameof(Sensor), request.Id, ct);
        return result;
    }
}