namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetDeviceByIdQuery(string Id) : IRequest<Result<DeviceDto?>>;
public class GetDeviceByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetDeviceByIdQuery, Result<DeviceDto?>>
{
    public async Task<Result<DeviceDto?>> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Devices
            .Where(x => x.Id == request.Id)
            .ToDeviceDto()
            .SingleOrNotFoundAsync(nameof(Device), request.Id, cancellationToken);
        return result;
    }
}