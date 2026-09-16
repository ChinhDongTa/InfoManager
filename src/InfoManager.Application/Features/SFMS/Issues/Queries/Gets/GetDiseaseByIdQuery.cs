namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record GetDiseaseByIdQuery(string Id) : IRequest<Result<DiseaseDto?>>;

public class GetDiseaseByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetDiseaseByIdQuery, Result<DiseaseDto?>>
{
    public async Task<Result<DiseaseDto?>> Handle(GetDiseaseByIdQuery request, CancellationToken ct)
    {
        var result = await context.Diseases
            .Where(x => x.Id == request.Id)
            .ToDiseaseDto()
            .SingleOrNotFoundAsync(nameof(Disease), request.Id, ct);
        return result;
    }
}