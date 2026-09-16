namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetGrowthStageByIdQuery(string Id) : IRequest<Result<GrowthStageDto?>>;

public class GetGrowthStageByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetGrowthStageByIdQuery, Result<GrowthStageDto?>>
{
    public async Task<Result<GrowthStageDto?>> Handle(GetGrowthStageByIdQuery request, CancellationToken ct)
    {
        var result = await context.GrowthStages
            .Where(x => x.Id == request.Id)
            .ToGrowthStageDto()
            .SingleOrNotFoundAsync(nameof(GrowthStage), request.Id, ct);
        return result;
    }
}