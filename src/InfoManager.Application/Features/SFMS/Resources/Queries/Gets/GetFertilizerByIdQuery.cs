namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetFertilizerByIdQuery(string Id) : IRequest<Result<FertilizerDto?>>;

public class GetFertilizerByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFertilizerByIdQuery, Result<FertilizerDto?>>
{
    public async Task<Result<FertilizerDto?>> Handle(GetFertilizerByIdQuery request, CancellationToken ct)
    {
        var result = await context.Fertilizers
            .Where(x => x.Id == request.Id)
            .ToFertilizerDto()
            .SingleOrNotFoundAsync(nameof(Fertilizer), request.Id, ct);
        return result;
    }
}