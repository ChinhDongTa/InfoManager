namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetCropVarietyByIdQuery(string Id) : IRequest<Result<CropVarietyDto?>>;
public class GetCropVarietyByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropVarietyByIdQuery, Result<CropVarietyDto?>>
{
    public async Task<Result<CropVarietyDto?>> Handle(GetCropVarietyByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.CropVarieties
            .Where(x => x.Id == request.Id)
            .ToCropVarietyDto()
            .SingleOrNotFoundAsync(nameof(CropVariety), request.Id, cancellationToken);
        return result;
    }
}
