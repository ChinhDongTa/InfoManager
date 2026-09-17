namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetPesticideByIdQuery(string Id) : IRequest<Result<PesticideDto?>>;

public class GetPesticideByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPesticideByIdQuery, Result<PesticideDto?>>
{
    public async Task<Result<PesticideDto?>> Handle(GetPesticideByIdQuery request, CancellationToken ct)
    {
        var result = await context.Pesticides
            .Where(x => x.Id == request.Id)
            .ToPesticideDto()
            .SingleOrNotFoundAsync(nameof(Pesticide), request.Id, ct);
        return result;
    }
}