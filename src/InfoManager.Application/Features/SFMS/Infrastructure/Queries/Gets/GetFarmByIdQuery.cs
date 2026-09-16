namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetFarmByIdQuery(string Id) : IRequest<Result<FarmDto?>>;

public class GetFarmByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmByIdQuery, Result<FarmDto?>>
{
    public async Task<Result<FarmDto?>> Handle(GetFarmByIdQuery request, CancellationToken ct)
    {
        var result = await context.Farms
            .Where(x => x.Id == request.Id)
            .ToFarmDto()
            .SingleOrNotFoundAsync(nameof(Farm), request.Id.ToString(), ct);
        return result;
    }
}