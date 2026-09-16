namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetCropPlantingByIdQuery(string Id) : IRequest<Result<CropPlantingDto?>>;

public class GetCropPlantingByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropPlantingByIdQuery, Result<CropPlantingDto?>>
{
    public async Task<Result<CropPlantingDto?>> Handle(GetCropPlantingByIdQuery request, CancellationToken ct)
    {
        var result = await context.CropPlantings
            .Where(x => x.Id == request.Id)
            .ToCropPlantingDto()
            .SingleOrNotFoundAsync(nameof(CropPlanting), request.Id, ct);
        return result;
    }
}