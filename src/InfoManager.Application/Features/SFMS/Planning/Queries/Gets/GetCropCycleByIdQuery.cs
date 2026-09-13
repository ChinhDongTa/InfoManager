namespace InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

public record GetCropCycleByIdQuery(string Id) : IRequest<Result<CropCycleDto?>>;
public class GetCropCycleByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropCycleByIdQuery, Result<CropCycleDto?>>
{
    public async Task<Result<CropCycleDto?>> Handle(GetCropCycleByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.CropCycles
            .Where(x => x.Id == request.Id)
            .ToCropCycleDto()
            .SingleOrNotFoundAsync(nameof(CropCycle), request.Id, cancellationToken);
        return result;
    }
}