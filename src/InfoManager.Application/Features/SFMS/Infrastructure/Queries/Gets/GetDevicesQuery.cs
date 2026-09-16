namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetDevicesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<DeviceDto>>>;

public class GetDevicesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetDevicesQuery, Result<PaginatedList<DeviceDto>>>
{
    public async Task<Result<PaginatedList<DeviceDto>>> Handle(GetDevicesQuery request, CancellationToken ct)
    {
        var result = await context.Devices
            .ApplySorting()
            .ToDeviceDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<DeviceDto>>.Success(result);
    }
}