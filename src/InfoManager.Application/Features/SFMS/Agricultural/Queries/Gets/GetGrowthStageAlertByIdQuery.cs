namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetGrowthStageAlertByIdQuery(string Id) : IRequest<Result<GrowthStageAlertDto?>>;
public class GetGrowthStageAlertByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetGrowthStageAlertByIdQuery, Result<GrowthStageAlertDto?>>
{
    public async Task<Result<GrowthStageAlertDto?>> Handle(GetGrowthStageAlertByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.GrowthStageAlerts
            .Where(x => x.Id == request.Id)
            .ToGrowthStageAlertDto()
            .SingleOrNotFoundAsync(nameof(GrowthStageAlert), request.Id, cancellationToken);
        return result;
    }
}