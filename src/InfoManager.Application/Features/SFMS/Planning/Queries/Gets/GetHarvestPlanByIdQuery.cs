namespace InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

public record GetHarvestPlanByIdQuery(string Id) : IRequest<Result<HarvestPlanDto?>>;

public class GetHarvestPlanByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHarvestPlanByIdQuery, Result<HarvestPlanDto?>>
{
    public async Task<Result<HarvestPlanDto?>> Handle(GetHarvestPlanByIdQuery request, CancellationToken ct)
    {
        var result = await context.HarvestPlans
            .Where(x => x.Id == request.Id)
            .ToHarvestPlanDto()
            .SingleOrNotFoundAsync(nameof(HarvestPlan), request.Id, ct);
        return result;
    }
}