namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record GetHarvestByIdQuery(string Id) : IRequest<Result<HarvestDto?>>;

public class GetHarvestByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHarvestByIdQuery, Result<HarvestDto?>>
{
    public async Task<Result<HarvestDto?>> Handle(GetHarvestByIdQuery request, CancellationToken ct)
    {
        var result = await context.Harvests
            .Where(x => x.Id == request.Id)
            .ToHarvestDto()
            .SingleOrNotFoundAsync(nameof(Harvest), request.Id, ct);
        return result;
    }
}