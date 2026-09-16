namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record GetInfestationByIdQuery(string Id) : IRequest<Result<InfestationDto?>>;

public class GetInfestationByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetInfestationByIdQuery, Result<InfestationDto?>>
{
    public async Task<Result<InfestationDto?>> Handle(GetInfestationByIdQuery request, CancellationToken ct)
    {
        var result = await context.Infestations
            .Where(x => x.Id == request.Id)
            .ToInfestationDto()
            .SingleOrNotFoundAsync(nameof(Infestation), request.Id, ct);
        return result;
    }
}