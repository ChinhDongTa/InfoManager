namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetFertilizationPlanByIdQuery(string Id) : IRequest<Result<FertilizationPlanDto?>>;

public class GetFertilizationPlanByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFertilizationPlanByIdQuery, Result<FertilizationPlanDto?>>
{
    public async Task<Result<FertilizationPlanDto?>> Handle(GetFertilizationPlanByIdQuery request, CancellationToken ct)
    {
        var result = await context.FertilizationPlans
            .Where(x => x.Id == request.Id)
            .ToFertilizationPlanDto()
            .SingleOrNotFoundAsync(nameof(FertilizationPlan), request.Id, ct);
        return result;
    }
}