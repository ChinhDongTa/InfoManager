namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetPesticideApplicationByIdQuery(string Id) : IRequest<Result<PesticideApplicationDto?>>;

public class GetPesticideApplicationByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPesticideApplicationByIdQuery, Result<PesticideApplicationDto?>>
{
    public async Task<Result<PesticideApplicationDto?>> Handle(GetPesticideApplicationByIdQuery request, CancellationToken ct)
    {
        var result = await context.PesticideApplications
            .Where(x => x.Id == request.Id)
            .ToPesticideApplicationDto()
            .SingleOrNotFoundAsync(nameof(PesticideApplication), request.Id, ct);
        return result;
    }
}