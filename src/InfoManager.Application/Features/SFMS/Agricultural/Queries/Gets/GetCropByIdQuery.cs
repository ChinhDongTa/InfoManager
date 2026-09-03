namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetCropByIdQuery(string Id) : IRequest<Result<CropDto?>>;
public class GetCropByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropByIdQuery, Result<CropDto?>>
{
    public async Task<Result<CropDto?>> Handle(GetCropByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Crops
            .Where(x => x.Id == request.Id)
            .ToCropDto()
            .SingleOrNotFoundAsync(nameof(Crop), request.Id, cancellationToken);
        return result;
    }
}
