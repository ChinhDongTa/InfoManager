namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record GetPestDiseaseLinkByIdQuery(string Id) : IRequest<Result<PestDiseaseLinkDto?>>;

public class GetPestDiseaseLinkByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPestDiseaseLinkByIdQuery, Result<PestDiseaseLinkDto?>>
{
    public async Task<Result<PestDiseaseLinkDto?>> Handle(GetPestDiseaseLinkByIdQuery request, CancellationToken ct)
    {
        var result = await context.PestDiseaseLinks
            .Where(x => x.Id == request.Id)
            .ToPestDiseaseLinkDto()
            .SingleOrNotFoundAsync(nameof(PestDiseaseLink), request.Id, ct);
        return result;
    }
}