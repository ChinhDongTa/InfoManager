namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record GetPestByIdQuery(string Id) : IRequest<Result<PestDto?>>;

public class GetPestByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPestByIdQuery, Result<PestDto?>>
{
    public async Task<Result<PestDto?>> Handle(GetPestByIdQuery request, CancellationToken ct)
    {
        var result = await context.Pests
            .Where(x => x.Id == request.Id)
            .ToPestDto()
            .SingleOrNotFoundAsync(nameof(Pest), request.Id, ct);
        return result;
    }
}