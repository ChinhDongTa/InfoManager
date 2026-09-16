namespace InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

public record GetPlantingPlanByIdQuery(string Id) : IRequest<Result<PlantingPlanDto?>>;

public class GetPlantingPlanByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPlantingPlanByIdQuery, Result<PlantingPlanDto?>>
{
    public async Task<Result<PlantingPlanDto?>> Handle(GetPlantingPlanByIdQuery request, CancellationToken ct)
    {
        var result = await context.PlantingPlans
            .Where(x => x.Id == request.Id)
            .ToPlantingPlanDto()
            .SingleOrNotFoundAsync(nameof(PlantingPlan), request.Id, ct);
        return result;
    }
}