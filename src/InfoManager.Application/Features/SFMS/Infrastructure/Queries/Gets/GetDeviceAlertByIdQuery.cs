namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetDeviceAlertByIdQuery(string Id) : IRequest<Result<DeviceAlertDto?>>;

public class GetDeviceAlertByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetDeviceAlertByIdQuery, Result<DeviceAlertDto?>>
{
    public async Task<Result<DeviceAlertDto?>> Handle(GetDeviceAlertByIdQuery request, CancellationToken ct)
    {
        var result = await context.DeviceAlerts
            .Where(x => x.Id == request.Id)
            .ToDeviceAlertDto()
            .SingleOrNotFoundAsync(nameof(DeviceAlert), request.Id, ct);
        return result;
    }
}