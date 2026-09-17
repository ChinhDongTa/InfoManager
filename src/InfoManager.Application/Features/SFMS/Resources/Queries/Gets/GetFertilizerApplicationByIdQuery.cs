namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetFertilizerApplicationByIdQuery(string Id) : IRequest<Result<FertilizerApplicationDto?>>;

public class GetFertilizerApplicationByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFertilizerApplicationByIdQuery, Result<FertilizerApplicationDto?>>
{
    public async Task<Result<FertilizerApplicationDto?>> Handle(GetFertilizerApplicationByIdQuery request, CancellationToken ct)
    {
        var result = await context.FertilizerApplications
            .Where(x => x.Id == request.Id)
            .ToFertilizerApplicationDto()
            .SingleOrNotFoundAsync(nameof(FertilizerApplication), request.Id, ct);
        return result;
    }
}