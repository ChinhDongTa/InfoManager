namespace InfoManager.Application.Features.SFMS.Production.Queries.Gets;

public record GetYieldByIdQuery(string Id) : IRequest<Result<YieldDto?>>;

public class GetYieldByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetYieldByIdQuery, Result<YieldDto?>>
{
    public async Task<Result<YieldDto?>> Handle(GetYieldByIdQuery request, CancellationToken ct)
    {
        var result = await context.Yields
            .Where(x => x.Id == request.Id)
            .ToYieldDto()
            .SingleOrNotFoundAsync(nameof(Yield), request.Id, ct);
        return result;
    }
}