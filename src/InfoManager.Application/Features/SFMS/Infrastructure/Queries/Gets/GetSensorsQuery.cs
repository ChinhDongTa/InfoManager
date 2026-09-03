namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetSensorsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<SensorSummaryDto>>>;
public class GetSensorsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSensorsQuery, Result<PaginatedList<SensorSummaryDto>>>
{
    public async Task<Result<PaginatedList<SensorSummaryDto>>> Handle(GetSensorsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Sensors
            .ApplySorting()
            .ToSensorSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<SensorSummaryDto>>.Success(result);
    }
}
